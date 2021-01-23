    String ConvertString(String inputString)
    {
        var first = new List<string>();
        var second = new List<string>();
        foreach (Match match in Regex.Matches(inputString, "(?<inTag><code[^>]+>[^<]*</code[^>]+>)"))
        {
            first.Add(match.Groups["inTag"].Value);
        }
        inputString = inputString.Replace(" ", "&nbsp;");
        foreach (Match match in Regex.Matches(inputString, "(?<inTag><code[^>]+>[^<]*</code[^>]+>)"))
        {
            second.Add(match.Groups["inTag"].Value);
        }
        for (int i = 0; i < first.Count(); i++)
        {
            inputString = inputString.Replace(second[i], first[i]);
        }
        return inputString;
    }
