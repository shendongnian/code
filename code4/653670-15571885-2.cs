    public static Task FromResult<T>(T result)
    {
        var tcs = new TaskCompletionSource<T>();
        tcs.SetResult(result);
        return tcs.Task;
    }
