    string input = "5 (3)";
    string pattern = @"(\d+) \((\d+)\)";
    var match = Regex.Match(input, pattern);
    if (match.Success)
    {
        int x = int.Parse(match.Groups[1].Value);
        int y = int.Parse(match.Groups[2].Value);
        ...
    }
    else
    {
        // Fail
        ...
    }
