    static void Main()
    {
        ThreadPool.SetMinThreads(21, 21);
        var sw = new Stopwatch();
        sw.Start();
        Enumerable.Range(0, 101).AsParallel().WithDegreeOfParallelism(21).ForAll(i => Thread.Sleep(i==0?5000:1000));
        Console.WriteLine(sw.ElapsedMilliseconds);
    }
