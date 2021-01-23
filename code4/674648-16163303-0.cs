    private volatile bool isRunning;
    public void Run()
    {
        this.isRunning = true;
        ThreadPool.QueueUserWorkItem(DoSomething);
    }
    public void Stop()
    {
        this.isRunning = false;
    }
    private void DoSomething(object state)
    {
        while (this.isRunning)
        {
            Console.WriteLine("working...");
            Thread.Sleep(1000);
        }
        Console.WriteLine("stopped.");
    }
