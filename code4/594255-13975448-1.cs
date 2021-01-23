    public Task<List<T>> GetDataAsync(IProxy proxy) {
        var tcs = new TaskCompletionSource<List<T>>();
        var asyncCallback = EndAsync(tcs, 
                                     proxy.EndGetData, 
                                     result => result != null ? 
                                               ProcessResult(result) : 
                                               new List<T>());
        proxy.BeginGetData(asyncCallback);
        return tcs.Task;
    }
    
