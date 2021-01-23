    private readonly int desiredConcurrency = 20;
    struct RequestData
    {
      public UrlInfo url;
      public HttpWebRequest request;
    }
    /// Handles the completion of an asynchronous request
    /// When a request has been completed,
    /// tries to issue a new request to another url.
    private void AsyncRequestHandler(IAsyncResult ar)
    {
      if (ar.IsCompleted)
      {
        RequestData data = (RequestData)ar.AsyncState;
        HttpWebResponse resp = data.request.EndGetResponse(ar);
        if (resp.StatusCode != 200)
        {
          BadUrls.Add(data.url);
        }
        
        //A request has been completed, try to start a new one
        TryIssueRequest();
      }
    }
    /// If urls is not empty, dequeues a url from it
    /// and issues a new request to the extracted url.
    private bool TryIssueRequest()
    {
      RequestData rd;
      if (urls.TryDequeue(out rd.url))
      {
        rd.request = CreateRequestTo(rd.url); //TODO implement
        rd.request.BeginGetResponse(AsyncRequestHandler, rd);
        return true;
      }
      else
      {
        return false;
      }
    }
    //Called by a button handler, or something like that
    void StartTheRequests()
    {
      for (int requestCount = 0; requestCount < desiredConcurrency; ++requestCount)
      {
        if (!TryIssueRequest()) break;
      }
    }
