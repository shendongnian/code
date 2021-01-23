    var list = Enumerable.Range(0, 723748).ToList();
    var stopwatch = new Stopwatch();
    for (int n = 0; n < 5; n++)
    {
        stopwatch.Reset();
        stopwatch.Start();
        for(int i = 0; i < list.Count; i += 100)
        {
            List<int> c = list.GetRange(i, Math.Min(100, list.Count - i));
        }
        stopwatch.Stop();
        Console.WriteLine("List<T>.GetRange: " + stopwatch.ElapsedMilliseconds.ToString());
        
        stopwatch.Reset();
        stopwatch.Start();
        for (int i = 0; i < list.Count; i += 100)
        {
            List<int> c = list.Skip(i).Take(100).ToList();
        }
        stopwatch.Stop();
        Console.WriteLine("Skip/Take: " + stopwatch.ElapsedMilliseconds.ToString());
        
        stopwatch.Reset();
        stopwatch.Start();
        var test = list.ToArray();
        for (int i = 0; i < list.Count; i += 100)
        {
            int length = Math.Min(100, list.Count - i);
            int[] c = new int[length];
            Array.Copy(test, i, c, 0, length);
        }
        stopwatch.Stop();
        Console.WriteLine("Array.Copy: " + stopwatch.ElapsedMilliseconds.ToString());
        
        stopwatch.Reset();
        stopwatch.Start();
        List<List<int>> chunks = list
            .Select((s, i) => new { Value = s, Index = i })
            .GroupBy(x => x.Index / 100)
            .Select(grp => grp.Select(x => x.Value).ToList())
            .ToList();
        stopwatch.Stop();
        Console.WriteLine("LINQ: " + stopwatch.ElapsedMilliseconds.ToString());
    }
