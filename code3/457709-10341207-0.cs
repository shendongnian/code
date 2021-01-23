    int counter = 0;
    int iterations = 1000000;
    Action d = () => {};
    
    var stopwatch = new System.Diagnostics.Stopwatch();
    stopwatch.Start();
    for (int i = 0; i < iterations; i++)
    {
        var asyncResult = d.BeginInvoke(ar =>
        {
            Interlocked.Increment(ref counter);
        }, null);
    }
    
    do { } while(counter < iterations);
    stopwatch.Stop();
    
    Console.WriteLine("Took {0}ms", stopwatch.ElapsedMilliseconds);
    Console.ReadLine();
