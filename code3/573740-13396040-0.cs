    var list = new List<Tuple<int, string, string>>();
    list.Add(Tuple.Create(4000,"Title 5", "My name is Carl"));
    list.Add(Tuple.Create(2000,"Title 1", "My name is Marco"));
    list.Add(Tuple.Create(4000,"Title 6", "My name is Jadett"));
    list.Add(Tuple.Create(3000,"Title 3", "My name is Paul"));
    list.Add(Tuple.Create(4000,"Title 4", "My name is Anthony"));
    list.Add(Tuple.Create(2000,"Title 2", "My name is Luca"));
    var sorted = list.OrderBy(k => k.Item1).
                      ThenBy(k => k.Item2).
                      ThenBy(k => k.Item3);
    foreach (var k in sorted)
    {
        Console.WriteLine(k);
    }
