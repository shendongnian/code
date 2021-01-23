    int[] array = new[] { 1, 2, 3, 1, 4, 5, 6, 7, 8, 8 };
    var duplicates = array
        .GroupBy(i => i)
        .Where(g => g.Count() > 1)
        .Select(g => g.Key);
    foreach (var d in duplicates)
        Console.WriteLine(d);
