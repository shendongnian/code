    void Test()
    {
        Random rnd = new Random();
        List<int> records = new List<int>();
        for(int i=0;i<2000000;i++)
        {
            records.Add(rnd.Next());
        }
        Action action1 = () =>
        {
            var res1 = records.GroupBy(r => r % 2)
                        .OrderBy(x => x.Key)
                        .Select(x => x.OrderBy(y => y))
                        .SelectMany(x => x)
                        .ToList();
        };
        Action action2 = () =>
        {
            var res2 = records.OrderBy(x => x % 2).ThenBy(x => x).ToList();
        };
        //Avoid counting JIT
        action1();
        action2();
        var sw = Stopwatch.StartNew();
        action1();
        long t1 = sw.ElapsedMilliseconds;
        sw.Restart();
        action2();
        long t2 = sw.ElapsedMilliseconds;
        Console.WriteLine(t1 + " " + t2);
    }
