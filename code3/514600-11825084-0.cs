    private static ManualResetEvent found = new ManualResetEvent(false);
    ...
    Task.Factory.StartNew<bool>(() => Find(paramA, paramB));     
    Task.Factory.StartNew<bool>(() => Find(paramC, paramD));     
    Task.Factory.StartNew<bool>(() => Find(paramE, paramF));     
    Task.Factory.StartNew<bool>(() => Find(paramG, paramH));  
     
    var result = found.WaitOne(TimeSpan.FromSeconds(10)); // wait with timeout of 10 secs
    // do something with result
    ...
    private static bool Find(int[,] m1, int[,] m2)          
    {          
        if (found.WaitOne(0)) // check whether MSE has already been set
            return false;        
          
        // Do work...
        found.Set();
    }
