    var consecutiveGroupsIndices = consecutiveGroups
        .OrderByDescending(kv => kv.Value.Count)
        .Select(kv => Enumerable.Range(kv.Key, kv.Value.Count).ToArray()
        .ToArray());
    foreach(var consIndexGroup in consecutiveGroupsIndices)
        Console.WriteLine(string.Join(",", consIndexGroup));
    Console.WriteLine(string.Join(",", uniques.Select(u => u.Item1)));
