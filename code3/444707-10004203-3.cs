    protected override Stream GetRestoreStream()
    {
        if (SkyDriveFolderId != null)
            return GetRestoreStreamAwait().Result;
        return Stream.Null;
    }
    private async Task<Stream> GetRestoreStreamAwait()
    {
        
        try
        {
        LiveConnectClient clientGetFileList = new LiveConnectClient(_session);
        TaskCompletionSource<LiveOperationCompletedEventArgs> tcs1 = new TaskCompletionSource<LiveOperationCompletedEventArgs>();
        EventHandler<LiveOperationCompletedEventArgs> d1 = 
            (o, e) => 
                { 
                    try
                    {
                        tcs1.TrySetResult(e); 
                    }
                    catch(Exception ex)
                    {
                        tcs1.TrySetResult(null);
                    }
                };
        clientGetFileList.GetCompleted += d1;
        clientGetFileList.GetAsync(SkyDriveFolderId + "/files");
        var result1 = await tcs1.Task;
        clientGetFileList.GetCompleted -= d1;
        
        // ... method continues for a while
       }
       catch(Exception ex)
       {
           return null;
       }
    }
