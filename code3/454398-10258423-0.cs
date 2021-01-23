    var str = "Sore | aye\r\nA    |   1 \r\nA    |   2\r\nA    |   3\r\nB    |   1\r\nB    |   2";
    var relations = str.Split(new[] {Environment.NewLine},
                              StringSplitOptions.RemoveEmptyEntries)
                       .Skip(1).Select(l => l.Split('|').Select(
                                       x => x.Trim()).ToArray()).ToArray();
    var relationsDic = new SortedDictionary<string, SortedSet<string>>();
    foreach (var relation in relations)
    {
        if (relationsDic.ContainsKey(relation[0]))
        {
            relationsDic[relation[0]].Add(relation[1]);
        }
        else
        {
            relationsDic[relation[0]] = new SortedSet<string> {relation[1]};
        }
    }
    foreach (var kvp in relationsDic)
    {
        Console.WriteLine(kvp.Key);
        foreach (var sub in kvp.Value)
        {
            Console.WriteLine("\t" + sub);
        }
    }
