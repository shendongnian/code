    void PerfTest()
    {
        var list = Enumerable.Range(0, 21).ToList();
            
        var t1 = GetDurationInMs(list.SubSets_LB);
        var t2 = GetDurationInMs(list.SubSets_Jodrell2);
        var t3 = GetDurationInMs(() => list.CalcCombinations(20));
        Console.WriteLine("{0}\n{1}\n{2}", t1, t2, t3);
    }
    long GetDurationInMs(Func<IEnumerable<IEnumerable<int>>> fxn)
    {
        fxn(); //JIT???
        var count = 0;
        var sw = Stopwatch.StartNew();
        foreach (var ss in fxn())
        {
            count = ss.Sum();
        }
        return sw.ElapsedMilliseconds;
    }
