    private static void ShowQueryWithCode(IEnumerable<string> names)
    {
        Console.WriteLine("LINQ Query in Code - show names that start with 'R'");
        // Assuming there are no null entries in the names collection
        var query = from name in names where name.StartsWith("R") select name;
        // This is the same thing as 
        // var query = names.Where(name => name.StartsWith("R"));
        foreach (var name in query)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine();
    }
