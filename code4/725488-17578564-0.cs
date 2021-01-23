    var lines = File.ReadLines("yourFile.ext");
    // this assumes you can hold the whole file in memory
    // uniqueness is defined by the first two columns
    var grouped = lines.GroupBy(line => string.Join(", ", line.Split(',').Take(2)))
                       .ToArray();
    // "unique entry and first occurrence of duplicate entry" -> first entry in group
    var unique = grouped.Select(g => g.First());
    var dupes = grouped.Where(g => g.Count() > 1)
                       .SelectMany(g => g);
    Console.WriteLine("unique");
    foreach (var name in unique)
        Console.WriteLine(name);
    Console.WriteLine("\nDupes");
    foreach (var name in dupes)
        Console.WriteLine(name);
