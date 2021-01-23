    const int MaxThreads = 4;
    const int ItemsToProcess = 10000;
    private Semaphore _sem = new Semaphore(MaxThreads, MaxThreads);
    void DoTheWork()
    {
        int s = 0;
        for (int i = 0; i < ItemsToProcess; ++i)
        {
            _sem.WaitOne();
            Data d = new Data();
            d.Pos = s;
            d.Num = i;
            ThreadPool.QueueUserWorkItem(Process, d);
            ++s;
            if (s >= 19)
                s = 0;
        }
        // All items have been assigned threads.
        // Now, acquire the semaphore "MaxThreads" times.
        // When counter reaches that number, we know all threads are done.
        int semCount = 0;
        while (semCount < MaxThreads)
        {
            _sem.WaitOne();
            ++semCount;
        }
        // All items are processed
        // Clear the semaphore for next time.
        _sem.Release(semCount);
    }
    void Process(object o)
    {
        // do the processing ...
        
        // release the semaphore
        _sem.Release();
    }
