    public static Task<T> Where<T>(this Task<T> task, Func<T, bool> predicate)
    {
        if (task == null) throw new ArgumentNullException("task");
        if (predicate == null) throw new ArgumentNullException("predicate");
        var tcs = new TaskCompletionSource<T>();
        task.ContinueWith((completed) =>
            {
                if (completed.IsFaulted) tcs.TrySetException(completed.Exception.InnerExceptions);
                else if (completed.IsCanceled) tcs.TrySetCanceled();
                else
                {
                    try
                    {
                        if (predicate(completed.Result))
                            tcs.TrySetResult(completed.Result);
                        else
                            tcs.TrySetCanceled();
                    }
                    catch (Exception ex)
                    {
                        tcs.TrySetException(ex);
                    }
                }
            });
        return tcs.Task;
    }
    public static Task<TResult> Select<T, TResult>(this Task<T> task, Func<T, TResult> selector)
    {
        if (task == null) throw new ArgumentNullException("task");
        if (selector == null) throw new ArgumentNullException("selector");
        var tcs = new TaskCompletionSource<TResult>();
        task.ContinueWith((completed) =>
        {
            if (completed.IsFaulted) tcs.TrySetException(completed.Exception.InnerExceptions);
            else if (completed.IsCanceled) tcs.TrySetCanceled();
            else
            {
                try
                {
                    tcs.TrySetResult(selector(completed.Result));
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }
        });
        return tcs.Task;
    }
