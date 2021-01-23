    string[] a1 = { "123", "456", "1" };
    string[] a2 = { "123", "456", "789", "0" };
    var intersection = a1.Intersect(a2); //get the intersection
    var exceptions1 = a1.Except(a2);     //get items from a1, that are not in a2
    var exceptions2 = a2.Except(a1);     //get items from a2, that are not in a1
    var result = new List<Tuple<string, string>>(); //the result set
    result.AddRange(intersection.Select(s => new Tuple<string, string>(s, s)));
    result.AddRange(exceptions1.Select(s => new Tuple<string, string>(s, null)));
    result.AddRange(exceptions2.Select(s => new Tuple<string, string>(null, s)));
    foreach (var t in result)
    {
        Console.WriteLine((t.Item1 ?? "null") + "\t" + (t.Item2 ?? "null"));
    }
