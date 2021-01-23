    void PerfTest()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < 21; i++) list.Add(i);
            
        var t1 = GetDurationInMs(() => list.SubSets_LB());
        var t2 = GetDurationInMs(() => list.SubSets_Jodrell());
        var t3 = GetDurationInMs(() => list.CalcCombinations(20));
        Console.WriteLine("{0}\n{1}\n{2}", t1, t2, t3);
    }
    long GetDurationInMs(Func<IEnumerable<IEnumerable<int>>> fxn)
    {
        fxn(); //JIT???
        int count = 0;
        Stopwatch sw = Stopwatch.StartNew();
        foreach (var ss in fxn())
        {
            count = ss.Sum();
        }
        return sw.ElapsedMilliseconds;
    }
