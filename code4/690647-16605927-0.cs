    var timeout = TimeSpan.FromSeconds(5);
    
    var actualTask = new Task<ProductEventArgs>(() =>
    {
        var longRunningTask = new Task<ProductEventArgs>(() =>
        {
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(10)); // simulates the long running computation
                return new ProductEventArgs();
            }
            catch (Exception e)
            {
                return new ProductEventArgs() { E = e };
            }
        }, TaskCreationOptions.LongRunning);
    
        longRunningTask.Start();
    
        if (longRunningTask.Wait(timeout)) return longRunningTask.Result;
    
        return new ProductEventArgs() { E = new Exception("timed out") };
    });
    
    actualTask.Start();
    
    actualTask.Wait();
    
    Console.WriteLine("{0}", actualTask.Result.E); // handling E
