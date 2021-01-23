    // Consumes ten elements, yields 5 results.
    Enumerable.Range(1, 1000000).Where(i => i % 2 == 0)
        .Take(5)
        .ToList();
    // Consumes one million elements, yields 5 results.
    Enumerable.Range(1, 1000000).Where(i => i % 2 == 0)
        .OrderByDescending(i => i)
        .Take(5)
        .ToList();
