    public static async void QueueSomeWork()
    {
        await Task.Run(() => { DoSomething(); });
    }
    
    static readonly object lockObject = new object();
    static void DoSomething()
    {
        lock (lockObject)
        {
            // implementation
        }
    }
