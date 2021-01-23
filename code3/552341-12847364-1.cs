    var delimiter = new[] {','};
    var splits = File.ReadLines("text.txt")
                     .Where(line => !string.IsNullOrWhiteSpace(line))
                     .Select(line => line.Split(delimiter));
                     // Add "StringSplitOptions.RemoveEmptyEntries" if you want
                     // Add ".Where(split => split.Length > 1)" to exclude empty keys
    var lookup = splits.ToLookup(split => split[0], split => split.Skip(1));
    var dict = lookup.ToDictionary(x => x.Key, x => x.SelectMany(s => s).ToList());
