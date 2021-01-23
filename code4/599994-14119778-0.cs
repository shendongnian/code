    public void DoSomething(int count) {
        // this function does the performance test
        for (int i = 0; i < count; ++i) {
            var c = wrappedDict.Number; wrappedDict.AddSomething(i.ToString(), "a");
        }
    }
    static void Execute(int count, bool show)
    {
        var obj1 = new TestClass(new WrappedDict1());
        var obj2 = new TestClass(new WrappedDict2());
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        GC.WaitForPendingFinalizers();
        var watch = Stopwatch.StartNew();
        obj1.DoSomething(count);
        watch.Stop();
        if(show) Console.WriteLine("#1: {0}ms", watch.ElapsedMilliseconds);
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        GC.WaitForPendingFinalizers();
        watch = Stopwatch.StartNew();
        obj2.DoSomething(count);
        watch.Stop();
        if(show) Console.WriteLine("#2: {0}ms", watch.ElapsedMilliseconds);
    }
    static void Main()
    {
        Execute(1, false); // for JIT
        Execute(1000000, true); // for measuring
    }
