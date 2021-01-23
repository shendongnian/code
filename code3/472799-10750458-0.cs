    var types = new[] {typeof(string), typeof(string), typeof(int)};
    var x = types
            .GroupBy(type => type)
            .ToDictionary(g => g.Key, g => g.Count());
    foreach (var kvp in x) {
        Console.WriteLine("Type {0}, Count {1}", kvp.Key, kvp.Value);
    }
    Console.WriteLine("string has a count of {0}", x[typeof(string)]);
