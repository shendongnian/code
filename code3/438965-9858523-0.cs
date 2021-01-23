    var inputs = new[] 
    { 
        "Jeremy is trying #20 times to [understand this]",
        "#20 Jeremy is trying [understand this] times to"
    };
    string pattern = @"(?<Number>#\d+\b)|(?<Subtitle>\[.+?])|\s*(?<Text>(?:.(?!#\d+\b|\[.*?]))+)\s*";
    foreach (var input in inputs)
    {
        Console.WriteLine("Input: " + input);
        foreach (Match m in Regex.Matches(input, pattern))
        {
            // skip first group, which is the entire matched text
            var group = m.Groups.Cast<Group>().Skip(1).First(g => g.Success);
            Console.WriteLine(group.Value);
        }
        Console.WriteLine();
    }
