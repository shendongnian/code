    var lines = new[] { "wierd", "a1", "b1", "b2", "b3", "a2", "b4", "a3", "b5", "b6" };
    List<List<string>> groups = lines
        .Select((x, i) => Tuple.Create(x, x.StartsWith("a") ? new int?(i) : null))
        .Aggregate(Tuple.Create<IEnumerable<Tuple<string, int>>, Nullable<int>>(Enumerable.Empty<Tuple<string, int>>(), null), 
            (acc, x) => x.Item2.HasValue
                ? Tuple.Create(acc.Item1.Concat(new[] { Tuple.Create(x.Item1, x.Item2 ?? -1) }), x.Item2)
                : Tuple.Create(acc.Item1.Concat(new[] { Tuple.Create(x.Item1, acc.Item2 ?? -1) }), acc.Item2))
        .Item1
        .GroupBy(x => x.Item2)
        .Select(x => x.Select(y => y.Item1).ToList())
        .ToList();
    foreach(var group in groups) 
    {
        Console.WriteLine("--New group--");
        foreach (var line in group)
        {
            Console.WriteLine(line);
        }
    }
