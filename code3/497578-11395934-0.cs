    IEnumerable<string> pets = new[] { "Cat", "dog", "Tiger", "Cat", "cat", "dog" };
    var test = pets
        .Where(p=>p.ToUpperInvariant() == "CAT" || p.ToUpperInvariant() == "DOG")
        .GroupBy(p => p.ToUpperInvariant())
        .OrderByDescending(g => g.Count())
        .SelectMany(p => p);
    foreach (string pet in test)
        Console.WriteLine(pet);
