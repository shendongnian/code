    public static Task CreateEmptyTask()
    {
        var tcs = new TaskCompletionSource<object>();
        tsc.SetResult(null);
        return tcs.Task;
    }
