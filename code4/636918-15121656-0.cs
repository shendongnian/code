    public delegate void Action();
    public static void Execute(IEnumerable<Action> actions, int maxConcurrentItems)
    {
        object key = new object();
        Queue<Action> queue = new Queue<Action>(actions);
        int count = 0;
        AutoResetEvent whenDone = new AutoResetEvent(false);
        WaitCallback callback = null;
        callback = delegate
        {
            Action action = null;
            lock (key)
            {
                if (queue.Count > 0)
                    action = queue.Dequeue();
            }
            if (action != null)
            {
                action();
                ThreadPool.QueueUserWorkItem(callback);
            }
            else
            {
                if (Interlocked.Increment(ref count) == maxConcurrentItems)
                    whenDone.Set();
            }
        };
        for (int i = 0; i < maxConcurrentItems; i++)
        {
            ThreadPool.QueueUserWorkItem(callback);
        }
        whenDone.WaitOne();
    }
