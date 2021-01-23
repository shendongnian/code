    WaitGroup waitGroup = new WaitGroup();
    ManualResetEventSlim signal = new ManualResetEventSlim(false);
    
    // or rather threads; whatever you need
    for (var i = 0; i < 10; i++)
    {
        var localClosure = i;
    
        var t = new Task(() =>
        {
            // IMPORTANT: YOU NEED TO STRUCTURE OF THE IMPLEMENTATION OF YOUR TASK/THREAD THIS WAY
            try
            {
                waitGroup.Add();
    
                // implementation
                // ...
    
                // waiting
                signal.Wait();
    
                Console.WriteLine("exited {0}", localClosure);
            }
            finally
            {
                waitGroup.Done();
            }
        }, TaskCreationOptions.PreferFairness);
    
        t.Start();
    }
    
    signal.Set();
    waitGroup.Wait();
    signal.Reset();
