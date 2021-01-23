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
            }
            catch (Exception e)
            {
                taskCompletionSource.SetException(e);
            }
            finally
            {
                taskCompletionSource.SetResult(result);
            }
        });
        initThreadAction?.Invoke(thread);
        thread.Start();
        return taskCompletionSource.Task;
    }
