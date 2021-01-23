    var input = new List<List<int>>() {
        new List<int> { 1, 6, 3, 2 },
        new List<int> { 3, 5, 2, 7 },
        new List<int> { 9, 6, 7, 2 }
    };
    var results = new List<List<int>>(input.Count);
    foreach (var list in input)
    {
        var rankDict = list.OrderBy(x => x).Select((v, i) => new { v, i }).ToDictionary(x => x.v, x => x.i);
        results.Add(list.Select(x => rankDict[x] + 1).ToList());
    }
    foreach (var list in results)
    {
        Console.WriteLine(string.Join(" ", list.Select(x => x.ToString())));
    }
