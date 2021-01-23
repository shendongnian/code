    var regex = new Regex(keyword);
    foreach (Match match in regex.Matches(input))
    {
        var index = match.Index;
        var overhead = index + 200 - input.Length + 1;
        if (overhead > 0)
        {
            index -= overhead;
        }
        var result = index < 0 ? input : input.Substring(index, 200);
        Console.WriteLine(result);
    }
