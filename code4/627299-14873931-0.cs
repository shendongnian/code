    public Task<bool> Submit(
        TaskScheduler ts, Func<bool> work, object state,
        TaskContinuationOptions taskContinuationOptions)
    {
        var task = Task.Factory.StartNew(_ => work(), state, _cts.Token);
        task.ContinueWith(OnTaskSignaled, _cts.Token, taskContinuationOptions,
                          TaskScheduler.Default);
        return task;
    }
