    void Main()
    {
        var tokenSource = new CancellationTokenSource();
        var myTask = Task.Factory
            .StartNew(() => DoWork(tokenSource.Token), tokenSource.Token);
            
        Thread.Sleep(1000);
        
        // ok, let's cancel it (well, let's "request it be cancelled")
        tokenSource.Cancel();
        // wait for the task to "finish"
        myTask.Wait();
    }
    
    public void DoWork(CancellationToken token)
    {
        while(!token.IsCancellationRequested)
        {
            // Do useful stuff here
            Console.WriteLine("Working!");
            Thread.Sleep(100);
        }
    }
