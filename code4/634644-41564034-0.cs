    using UnityEngine;
    public class ExceptionManager : MonoBehaviour
    {
    	void Awake()
    	{
            var instance = FindObjectOfType<ExceptionManager>();
            if(instance!=null) Destroy(instance.gameObject);
 
    		Application.logMessageReceived += HandleException;
            DontDestroyOnLoad(gameObject);
    	}
    
    	void HandleException(string condition, string stackTrace, LogType type)
    	{
    		if (type == LogType.Exception)
    		{
                 //handle here
    		}
    	}
    }
