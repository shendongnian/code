    string input = @"1. This is a text
        where each item can span over multiple lines
        2. that I want to
        extract each seperate
        item from
        3. How can I do that?";
    string pattern = @"([\d]+\. )(.*?)(?=([\d]+\.)|($))";
    var matches = Regex.Matches(input, pattern, RegexOptions.Singleline);
    foreach(Match match in matches)
    {
        Console.WriteLine(match.Groups[2].Value);
    }
