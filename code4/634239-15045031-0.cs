    System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
    watch.Start();
    testmethod(info);
    watch.Stop();
    Console.WriteLine(watch.ElapsedTicks);  // 2218 ticks
    
    watch.Restart();
    testmethod((MainInfo)info);
    watch.Stop();
    Console.WriteLine(watch.ElapsedTicks); // 135 ticks
