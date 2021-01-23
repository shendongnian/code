    public static readonly Task EmptyTask = Task.FromResult<object>(null);
    
    Task t = EmptyTask;
    t.Dispose();
    ((IAsyncResult)t).AsyncWaitHandle.WaitOne();
