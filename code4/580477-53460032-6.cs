    var taskCompletionSource = new TaskCompletionSource<bool>();
    Thread t = new Thread(() =>
    {
        try
        {
            Operation();
            taskCompletionSource.TrySetResult(true);
        }
        catch (Exception e)
        {
            taskCompletionSource.TrySetException(e);
        }
    });
    void Operation()
    {
        // Some work in thread
    }
    t.Start();
    await taskCompletionSource.Task;
