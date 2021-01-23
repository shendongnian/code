        const int size = 1000000;
        var dict = new Dictionary<int, string>();
        for (int i = 0; i < size; i++)
        {
            dict.Add(i, i.ToString());
        }
        var sw = new Stopwatch();
        string result;
        sw.Start();
        for (int i = 0; i < size; i++)
        {
            if (dict.ContainsKey(i))
                result = dict[i];
        }
        sw.Stop();
        Console.WriteLine("ContainsKey + Item for {0} hits: {1}ms", size, sw.ElapsedMilliseconds);
        sw.Reset();
        sw.Start();
        for (int i = 0; i < size; i++)
        {
            dict.TryGetValue(i, out result);
        }
        sw.Stop();
        Console.WriteLine("TryGetValue for {0} hits: {1}ms", size, sw.ElapsedMilliseconds);
    }
