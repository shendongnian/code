     public override void UpdateCanvas(object parameter)
     {
          Action<GraphPane> startToUpdate = StartToUpdate;
           GraphPane selectedPane = Canvas.HostingPane.PaneList.Find(p =>  p.Title.Text.Equals(defaultPanTitle));
           startToUpdate.BeginInvoke(selectedPane, FormSyncContext.SyncContextCallback(RefreshCanvas), selectedPane);
     }
    
     public static AsyncCallback SyncContextCallback(AsyncCallback callback)
     {
           // Capture the calling thread's SynchronizationContext-derived object
           SynchronizationContext sc = SynchronizationContext.Current;
    
           // If there is no SC, just return what was passed in
           if (sc == null) return callback;
    
           // Return a delegate that, when invoked, posts to the captured SC a method that
           // calls the original AsyncCallback passing it the IAsyncResult argument
           return asyncResult => sc.Post(result => callback((IAsyncResult)result), asyncResult);
     }
