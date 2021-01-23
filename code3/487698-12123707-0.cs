    // from main
    Time(Functional, "Functional", a);    
    Time(Linq, "Linq", a);    
    Time(Iterative, "Iterative", a);
    // ...
    static int reps = 1000;
    private static List<int> Time(Func<int[],List<int>> func, string name, int[] a)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        List<int> ret = null;
        for(int i = 0; i < reps; ++i)
        {
            ret = func(a);
        }
        sw.Stop();
        Console.WriteLine(
            "{0} per call timings - {1} ticks, {2} ms",
            name,
            sw.ElapsedTicks/(double)reps,
            sw.ElapsedMilliseconds/(double)reps);
        return ret;
    }
