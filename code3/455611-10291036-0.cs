        var numbers = Enumerable.Range(1, 10000000);
        var sw = Stopwatch.StartNew();
        int max = numbers.Max();
        Console.WriteLine(sw.ElapsedMilliseconds);
        sw.Restart();
        int max2 = numbers.OrderByDescending(x => x).First();
        Console.WriteLine(sw.ElapsedMilliseconds);
