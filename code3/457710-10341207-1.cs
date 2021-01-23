    int counter = 0;
    int iterations = 1000000;
    Action d = () => { Interlocked.Increment(ref counter); };
    
    var stopwatch = new System.Diagnostics.Stopwatch();
    stopwatch.Start();
    for (int i = 0; i < iterations; i++)
    {
        var asyncResult = d.BeginInvoke(null, null);
    }
    
    do { } while(counter < iterations);
    stopwatch.Stop();
    
    Console.WriteLine("Took {0}ms", stopwatch.ElapsedMilliseconds);
    Console.ReadLine();
