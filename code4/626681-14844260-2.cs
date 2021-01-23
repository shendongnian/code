    //init original dictionary
    var dict = new Dictionary<string, List<string>>
    {
        {"A1",new List<string> { "B1", "B2", "B3" }},
        {"A2",new List<string> { "B1" }},
        {"A3",new List<string> { "B1", "B2"}},
    };
    //do the task
    var newdict = new Dictionary<string, List<string>>();
    foreach (var p in dict)
    {
        foreach (string s in p.Value)
        {
            if (!newdict.ContainsKey(s))
                newdict[s] = new List<string>();
            newdict[s].Add(p.Key);
        }
    }
    //see what we've got
    foreach (var p in newdict)
    {
        Console.WriteLine(p.Key);
        foreach (string s in p.Value)
        {
            Console.Write(s + "\t");
        }
        Console.WriteLine();
    }
    Console.ReadLine();
