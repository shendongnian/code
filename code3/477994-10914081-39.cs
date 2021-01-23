    var employees = new List<string> { "Adam", "Bob", "James" };
    var jobs = new List<string> {"1", "2"};
    var prevStrs = new List<string>();
    foreach (var group in CombinationsEx.GroupCombined(employees, jobs))
    {
        var currStr = string.Join(Environment.NewLine,
                                  group.Select(sub =>
                                               string.Format("{0}: {1}",
                                                   string.Join(", ", sub.Key),
                                                   string.Join(", ", sub))));
        if (prevStrs.Contains(currStr))
        {
            continue;
        }
        prevStrs.Add(currStr);
        Console.WriteLine(currStr);
        Console.WriteLine();
        c++;
    }
    Console.WriteLine(c + " combinations.");
