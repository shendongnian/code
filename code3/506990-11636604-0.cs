    List<Tuple<int, int>> flattened = (
            from x in allLists.Select((list, index) => new
            {
                List = list,
                Position = index + 1
            })
            from i in x.List
            select Tuple.Create(x.Position, i)
        ).ToList();
    // now you have all numbers flattened in one list:
    foreach (var t in flattened)
    {
        Console.WriteLine("Number: " + t.Item2); // prints out the number
    }
    // unflatten
    allLists = flattened.GroupBy(t => t.Item1)
                        .Select(g => g.Select(t => t.Item2).ToList())
                        .ToList();
