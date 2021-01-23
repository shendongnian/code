    public static Task<IEnumerable<T>> ToSequence<T>(this Task<T> task)
    {
        var tcs = new TaskCompletionSource<IEnumerable<T>>();
        task.ContinueWith(_ =>
        {
            if (task.IsCanceled)
                tcs.SetCanceled();
            else if (task.IsFaulted)
                tcs.SetException(task.Exception);
            else
                tcs.SetResult(Enumerable.Repeat(task.Result, 1));
        });
    
        return tcs.Task;
    }
    
