    public Task<string> GetSomeData(CancellationToken token)
    {
        var tcs = new TaskCompletionSource<string>();
        Task<int> task1 = GetSomeInteger(token);
        Task<Task<string>> task2 = task1.ContinueWith(t => GetSomeString(t.Result, token));
        task2.ContinueWith(t => tcs.SetResult(t.Result.Result));
        return tcs.Task;
    }
