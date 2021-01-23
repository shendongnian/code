    var taskCompletionSource = new TaskCompletionSource<bool>();
    Thread t = new Thread(() =>
    {
        bool taskDummyResult = false;
        try
        {
            Operation();
            taskDummyResult = true;
        }
        catch (Exception e)
        {
            taskCompletionSource.SetException(e);
        }
        finally
        {
            taskCompletionSource.SetResult(taskDummyResult);
        }
        Operation();    
    });
    void Operation()
    {
        // Some work in thread
    }
    t.Start();
    await taskCompletionSource.Task;
