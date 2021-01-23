    var t1 = DateTime.UtcNow;
    for (int i = 0; i < 1000000; ++i)
    {
        long dummy;
        QueryPerformanceCounter(out dummy);
    }
    var t2 = DateTime.UtcNow;
    Console.WriteLine("Elapsed = " + (t2-t1).TotalMilliseconds);
