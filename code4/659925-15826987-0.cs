    class CoroutineServiceAsync : IServiceAsync
    {
        public void SendRequest(string url, Action<string> callback, string data)
        {
            Debug.Log("Sending service call with data: " + data);
            GameObject obj = new GameObject("ServiceCall: " + data);
            CoRoutineRequest packet = obj.AddComponent<CoRoutineRequest>();
            packet.SendRequest(url, callback, data);
        }
    }
 
    class CoRoutineRequest : MonoBehaviour
    {
        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
 
        public void SendRequest(string url, Action<string> callback, string data)
        {
            StartCoroutine(StartSendRequest(url, callback, data));
        }
 
        IEnumerator StartSendRequest(string url, Action<string> callback, string data)
        {
            WWW www = new WWW(url + "/" + data);
            yield return www;
 
            if (callback != null)
                callback(www.text);
 
            Destroy(gameObject);
        }
    }
