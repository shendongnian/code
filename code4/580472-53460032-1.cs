    public static Task RunInThread(
        this Action action,
        Action<Thread> initThreadAction = null)
    {
        TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
        Thread thread = new Thread(() =>
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                taskCompletionSource.SetException(e);
            }
            finally
            {
                taskCompletionSource.SetResult(true);
            }
        });
        initThreadAction?.Invoke(thread);
        thread.Start();
        return taskCompletionSource.Task;
    }
