    List<string> values = new List<string>();
    string pattern = @"\""(?<key>[^\""]+)\""\:\""?(?<value>[^\"",}]+)\""?\,?";
    foreach(Match m in Regex.Matches(input, pattern))
    {
        if (m.Success)
        {
            values.Add(m.Groups["value"].Value);
            //keys.Add(m.Groups["key"].Value);
        }
    }
    result = values.ToArray();
