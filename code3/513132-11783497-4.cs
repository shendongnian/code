    public Task<string> GetSomeData(CancellationToken token)
    {
        Task<Task<string>> task = GetSomeInteger(token)
                                   .ContinueWith(t => 
                                   {
                                       return GetSomeString(t.Result, token);
                                   }, token);
        return task.Unwrap();
    }
