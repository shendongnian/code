    public static Task<T> Unwrap<T>(this Task<Task<T>> task)
    {
        var tcs = new TaskCompletionSource<T>();
    
        task.ContinueWith(t =>
        {
            t.Result.ContinueWith(innerT => tcs.SetResult(innerT.Result)
                , TaskContinuationOptions.OnlyOnRanToCompletion);
            t.Result.ContinueWith(innerT => tcs.SetCanceled()
                , TaskContinuationOptions.OnlyOnCanceled);
            t.Result.ContinueWith(innerT => tcs.SetException(innerT.Exception.InnerExceptions)
                , TaskContinuationOptions.OnlyOnRanToCompletion);
        }
            , TaskContinuationOptions.OnlyOnRanToCompletion);
        task.ContinueWith(t => tcs.SetCanceled()
            , TaskContinuationOptions.OnlyOnCanceled);
        task.ContinueWith(t => tcs.SetException(t.Exception.InnerExceptions)
            , TaskContinuationOptions.OnlyOnFaulted);
    
        return tcs.Task;
    }
