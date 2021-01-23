    // Fixed the loop boundary as well
    for (int i = 0; i < numThreads; i++)
    {
        int copy = i;
        new Thread(() => // Use a lambda expression for brevity
        {
            // Fix naming convention for method name, too...
            TestWebWorking(urls[copy]);
            if (Interlocked.Decrement(ref toProcess) == 0))
            {
                resetEvent.Set();
            }
        }).Start()
    }
