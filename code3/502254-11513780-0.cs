    var groups = list
        .Select((f, i) => new
        {
            Foo = f,
            Index = i,
            NextFoo = list.ElementAtOrDefault(i + 1),
            PrevFoo = list.ElementAtOrDefault(i - 1)
        })
        .Select(x => new
        {
            A = x.Foo.A,
            SameA = (x.NextFoo != null && x.NextFoo.A == x.Foo.A)
                 || (x.PrevFoo != null && x.PrevFoo.A == x.Foo.A),
            x.Foo,
            x.Index
        })
        .GroupBy(x => new { x.SameA, x.A })
        .ToLookup(g => g.Key.A, g => g.Select(x => x.Foo.B));
    foreach (var abGroup in groups)
    {
        int aKey = abGroup.Key;
        var bList = string.Join(",", abGroup);
        Console.WriteLine("A = {0}, Bs = [ {1} ] ", aKey, bList);
    }
