    var groups = new Dictionary<string, string>
    {
        { "0", "group-09" },
        { "1", "group-09" },
        { "2", "group-09" },
        ...
        { "A", "group-ABC" },
        ...
    };
    var query = from item in myList
                group item by groups[item.GroupId];
    foreach (var group in query)
    {
        Console.WriteLine("id: " + group.Key);
        foreach (var item in group)
        {
            Console.WriteLine("       " + item.Title);
        }
    }
