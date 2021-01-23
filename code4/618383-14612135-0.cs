    private readonly SemaphoreSlim JobComplete = new SemaphoreSlim(0, 1);
    private readonly SemaphoreSlim WakeUp = new SemaphoreSlim(0, 1);
    private void AsyncLoop()
    {
        while (true)
        {
            MakeVerySimpleJob();
            WakeUpCondition = "As fast as u can!";
            JobComplete.Release();
            WakeUp.Wait();
        }
    }
    private void main()
    {
        Thread MyThread = new Thread(AsyncLoop);
        MyThread.Start();
        for (int i = 0; i < 100000; i++)
        {
            JobComplete.Wait();
            WakeUpCondition = null;
            WakeUp.Release();
        }
    }
