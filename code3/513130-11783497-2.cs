    public Task<string> GetSomeData(CancellationToken token)
    {
        var tcs = new TaskCompletionSource<string>();
        var task1 = GetSomeInteger(token);
        var task2 = task1.ContinueWith(t => GetSomeString(t.Result, token));
        task2.ContinueWith(t => tcs.SetResult(t.Result));
        return tcs.Task;
    }
