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
                taskCompletionSource.TrySetResult(true);
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
