    var str = "welcome";
    var items = Enumerable
        .Range(0, str.Length)
        .SelectMany(i => Enumerable.Range(2, str.Length-i-1).Select(j => str.Substring(i, j)))
        .Distinct()
        .OrderBy(s => s.Length);
    foreach (var s in items) {
        Console.WriteLine(s);
    }
