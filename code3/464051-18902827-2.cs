    private static AsyncCallback SyncContextCallback(AsyncCallback callback) 
    {
      SynchronizationContext sc = SynchronizationContext.Current;
      // If there is no SC, just return what was passed in
      if (sc == null) return callback;
      // Return a delegate that, when invoked, posts to the captured SC a method that
      // calls the original AsyncCallback passing it the IAsyncResult argument
      return asyncResult => sc.Post(result => callback((IAsyncResult)result), asyncResult);
    }
    
    protected override void OnMouseClick(MouseEventArgs e) {
      // The GUI thread initiates the asynchronous Web request
      Text = "Web request initiated";
      var webRequest = WebRequest.Create("http://Wintellect.com/");
      webRequest.BeginGetResponse(SyncContextCallback(ProcessWebResponse), webRequest);
      base.OnMouseClick(e);
    }
    private void ProcessWebResponse(IAsyncResult result) {
      // If we get here, this must be the GUI thread, it's OK to update the UI
      var webRequest = (WebRequest)result.AsyncState;
      using (var webResponse = webRequest.EndGetResponse(result)) {
          Text = "Content length: " + webResponse.ContentLength;
      }
    }
