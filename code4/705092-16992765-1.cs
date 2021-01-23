    static long numberOfQueuedTasks = 0;
    const long MAX_TASKS = 10000; // it depends how DoSomething internals consume resource
    public static async void QueueSomeWork()
    {
        if (numberOfQueuedTasks > MAX_TASKS)
        {
            var wait = new SpinWait();
    
            while (numberOfQueuedTasks > MAX_TASKS) wait.SpinOnce();
        }
    
        await Task.Run(() => { Interlocked.Increment(ref numberOfQueuedTasks); DoSomething(); });
    }
    
    static readonly object lockObject = new object();
    static void DoSomething()
    {
        try
        {
            lock (lockObject)
            {
                // implementation
            }
        }
        finally
        {
            Interlocked.Decrement(ref numberOfQueuedTasks);
        }
    }
