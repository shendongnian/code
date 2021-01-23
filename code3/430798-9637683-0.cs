    var list = new List<MyType>();
    // Fill the list
    ...
    // Create the index dictionary
    var propIndexes = list
        .Select((obj, i) => new { obj.Property, i })
        .GroupBy(x => x.Property)
        .ToDictionary(g => g.Key,
                      g => g.Select(x => x.i).ToList());
    // Iterate the objects having one specific property
    foreach (int i in propIndexes["value_i_need"]) {
        Console.WriteLine(list[i]);
    }
