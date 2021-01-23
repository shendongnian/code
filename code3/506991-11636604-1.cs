    // create sample data
    var allLists = new List<List<int>>() { 
        new List<int>(){ 1,2,3 },
        new List<int>(){ 4,5,6 },
        new List<int>(){ 7,8,9 },
    };
    List<Tuple<int, int>> flattened = allLists
        .Select((l, i) => new{ List = l, Position = i + 1 })
        .SelectMany(x => x.List.Select(i => Tuple.Create(x.Position, i)))
        .ToList();
    // now you have all numbers flattened in one list:
    foreach (var t in flattened)
    {
        Console.WriteLine("Number: " + t.Item2); // prints out the number
    }
    // unflatten
    allLists = flattened.GroupBy(t => t.Item1)
                        .Select(g => g.Select(t => t.Item2).ToList())
                        .ToList();
