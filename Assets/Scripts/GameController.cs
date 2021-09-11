using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static int numObjects = 100;

    static GameController Instance;
    [SerializeField]
    Button buttonSingleThread;
    [SerializeField]
    Button buttonJobSystem;
    [SerializeField]
    InputField inputfieldObjectCount;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        Instance = this;

        buttonSingleThread.onClick.AddListener(OnClickSingleThread);
        buttonJobSystem.onClick.AddListener(OnClickJobSystem);
        inputfieldObjectCount.onValueChanged.AddListener(OnInputFieldObjectsCount);

        inputfieldObjectCount.text = numObjects.ToString();
    }

    void OnClickSingleThread()
    {
        SceneManager.LoadScene("Singlethread_scene");
    }

    void OnClickJobSystem()
    {
        SceneManager.LoadScene("JobSystem_scene");
    }

    void OnInputFieldObjectsCount( string newInput)
    {
        int result;
        if ( int.TryParse(newInput, out result) )
        {
            numObjects = result;
        }
        else
        {
            inputfieldObjectCount.text = numObjects.ToString();
        }
    }
}
