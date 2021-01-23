    public static Task ForEachAsync(IEnumerable<Func<Task>> tasks)
    {
        var tcs = new TaskCompletionSource<bool>();
    
        Task currentTask = Task.FromResult(false);
    
        foreach (Func<Task> function in tasks)
        {
            currentTask.ContinueWith(t => tcs.TrySetException(t.Exception.InnerExceptions)
                , TaskContinuationOptions.OnlyOnFaulted);
            currentTask.ContinueWith(t => tcs.TrySetCanceled()
                    , TaskContinuationOptions.OnlyOnCanceled);
            Task<Task> continuation = currentTask.ContinueWith(t => function()
                , TaskContinuationOptions.OnlyOnRanToCompletion);
            currentTask = continuation.Unwrap();
        }
    
        currentTask.ContinueWith(t => tcs.TrySetException(t.Exception.InnerExceptions)
                , TaskContinuationOptions.OnlyOnFaulted);
        currentTask.ContinueWith(t => tcs.TrySetCanceled()
                , TaskContinuationOptions.OnlyOnCanceled);
        currentTask.ContinueWith(t => tcs.TrySetResult(true)
                , TaskContinuationOptions.OnlyOnRanToCompletion);
    
        return tcs.Task;
    }
