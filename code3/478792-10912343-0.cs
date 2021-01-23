    static void Main(string[] args)
    {
        const int size = 9000000;
        BenchIt("Parallel", ParallelCalculatePrimesUpTo, size);
        BenchIt("Ordered ", OrderedParallelCalculatePrimesUpTo, size);
        Console.ReadKey();
    }
    public static void BenchIt(string desc, Func<int, IEnumerable<int>> myFunc, int size)
    {
        var sw = new Stopwatch();            
        sw.Restart();
        myFunc.Invoke(size).ToList();
        sw.Stop();
        Console.WriteLine("{0} {1}",desc, sw.Elapsed);
    }
