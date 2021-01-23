    // Place this on the main thread's class initialization.
    private static readonly SynchronizationContext _syncContext =
        SynchronizationContext.Current;
    // Then your worked thread will be like this:
    if (len < 1)                  
    {
        Thread.Sleep(200);
        continue;
    }
    else
    {
        _syncContext.Post(o => MainThreadClass.ReceiveData((byte[])buff), buff);
    }
