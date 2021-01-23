    public Task<YourResultType> GetResultAsync(string change)
    {
        var tcs = new TaskCompletionSource<YourResultType>();
        
        // resultReceived object must be differnt instance for each ReturnOnChange call
        resultReceived += (o, ea) => {
               // check error
    
               tcs.SetResult(ea.Info);
             };
    
        ReturnOnChange(change); // as you mention this is async
    
        return tcs.Task;
    
    }
