    public static Task<TResult> RunInThread<T1, T2, TResult>(
        this Func<T1, T2, TResult> function,
        T1 param1,
        T2 param2,
        Action<Thread> initThreadAction = null)
    {
        TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
        Thread thread = new Thread(() =>
        {
            TResult result = default;
            try
            {
                result = function(param1, param2);
                taskCompletionSource.TrySetResult(result);
            }
            catch (Exception e)
            {
                taskCompletionSource.TrySetException(e);
            }
        });
        initThreadAction?.Invoke(thread);
        thread.Start();
        return taskCompletionSource.Task;
    }
