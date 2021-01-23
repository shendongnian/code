         WbAws.LoadingFrameCompleted += OnLoadingFrameCompleted;
         WbAws.Source = new Uri("http://google.com");
    
    private void OnLoadingFrameCompleted(...)
    { 
       if (webView == null || !webView.IsLive || 
             webView.ParentView != null || !e.IsMainFrame)
         return;
        LoadingFrameCompleted -= OnLoadingFrameCompleted;
        // do something
    }
