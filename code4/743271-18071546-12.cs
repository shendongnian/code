    public static Task<T> IfCanceled<T>(this Task<T> task, T defaultValue)
    {
        if (task == null) throw new ArgumentNullException("task");
        var tcs = new TaskCompletionSource<T>();
        task.ContinueWith((completed) =>
        {
            if (completed.IsFaulted) tcs.TrySetException(completed.Exception.InnerExceptions);
            else if (completed.IsCanceled) tcs.TrySetResult(defaultValue);
            else tcs.TrySetResult(completed.Result);
        });
        return tcs.Task;
    }
