    var employees = new List<string>() { "Adam", "Bob"};
    var jobs      = new List<string>() { "1", "2", "3"};
    var c = 0;
    foreach (var group in CombinationsEx.Group(employees, jobs))
    {
        foreach (var sub in group)
        {
            Console.WriteLine(sub.Key + ": " + string.Join(", ", sub));
        }
        c++;
        Console.WriteLine();
    }
    Console.WriteLine(c + " combinations.");
