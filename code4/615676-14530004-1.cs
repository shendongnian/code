    int count = 0;
    Semaphore s = new Semaphore(2, 2);
    AutoResetEvent[] waitHandles = new AutoResetEvent[10];
    for (int x = 0; x < 10; x++)
        waitHandles[x] = new AutoResetEvent(false);
    for (int x = 0; x < 10; x++)
    {
        Thread t = new Thread(threadNumber =>
            {
                s.WaitOne();
                Thread.Sleep(1000);
                Interlocked.Increment(ref count);
                waitHandles[(int)threadNumber].Set();
                s.Release();
            });
        t.Start(x);
    }
    WaitHandle.WaitAll(waitHandles);
    Console.WriteLine("done: {0}", count);
