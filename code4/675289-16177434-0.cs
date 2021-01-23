    string input = "bla:bla: blaspecial:1\r\n...";
    int sum = 0;
    var matches = Regex.Matches(input, @"^.*:(?<digit>\d)\s*$", RegexOptions.Multiline);
    foreach (Match match in matches)
    {
        var group = match.Groups["digit"];
        if (group.Success)
        {
            int value = Int32.Parse(group.Value);
            sum += value;
        }
    }
    Console.WriteLine(sum);
    
