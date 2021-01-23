    HttpWebRequest webRequest;
    void StartWebRequest()
    {
        webRequest.BeginGetResponse(new AsyncCallback(FinishWebRequest), null);
    }
    void FinishWebRequest(IAsyncResult result)
    {
        webRequest.EndGetResponse(result);
    }
