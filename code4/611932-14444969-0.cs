        Dictionary<int, string> d = new Dictionary<int, string>();
        d.Add(1000, "F1");
        d.Add(1001, "F2");
        d.Add(1002, "F1");
        d.Add(1003, "F4");
        d.Add(1004, "F2");
        var dublicate = d.ToLookup(x => x.Value, x => x.Key).Where(x => x.Count() > 1);
        foreach (var i in dublicate)
        {
            Console.WriteLine(i.Key);
        }
