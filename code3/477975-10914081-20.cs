    var c2 = 0;
    foreach (var group in CombinationsEx.GroupCombined(employees, jobs))
    {
        foreach (var sub in group)
        {
            Console.WriteLine(string.Join(", ", sub.Key) + ": " + string.Join(", ", sub));
        }
        c2++;
        Console.WriteLine();
    }
    Console.WriteLine(c2 + " combined combinations.");
