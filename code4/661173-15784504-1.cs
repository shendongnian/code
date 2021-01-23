    System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
    watch.Start();
    for(int i = 0; i <= 100000; i++)
    {
        //        
    }
    watch.Stop();
    Console.WriteLine("Time elapsed (ms): {0}", watch.Elapsed.TotalMilliseconds);
