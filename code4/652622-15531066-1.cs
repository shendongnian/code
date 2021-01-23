    private static int ActiveThreadCount = 0;
    // Set this to an appropriate number, or initialize from a config file.
    private static int MaxConcurrentThreads = 16;
    public void OnEndAsync(IAsyncResult result)
    {
        // An action to consume the ConcurrentQueue.
        Action action = () =>
        {
            Action op;
            try
            {
                while (imageOperations.TryDequeue(out op))
                {
                    op();
                }
            }
            finally
            {
                System.Threading.Interlocked.Decrement(ref ActiveThreadCount);
            }
        };
        // Start our optimal number of concurrent consuming actions.
        while (!imageOperations.IsEmpty &&
               System.Threading.Interlocked.Increment(ref ActiveThreadCount) <= MaxConcurrentThreads)
        {
            Task.Factory.StartNew(action);
        }
    }
