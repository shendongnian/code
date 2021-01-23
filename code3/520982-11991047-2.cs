    var query = people.GroupBy(person => new { person.Age, person.Sex },
                               person => person.Department);
    foreach (var group in query)
    {
        Console.WriteLine(group.Key);
        foreach (var department in group)
        {
            Console.WriteLine("  {0}", department);
        }
    }
