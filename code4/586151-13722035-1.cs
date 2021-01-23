    List<string> values = new List<string>();
    List<string> keys= new List<string>();
    string pattern = @"\""(?<key>[^\""]+)\""\:\""?(?<value>[^\"",}]+)\""?\,?";
    foreach(Match m in Regex.Matches(input, pattern))
    {
        if (m.Success)
        {
            values.Add(m.Groups["value"].Value);
            keys.Add(m.Groups["key"].Value);
        }
    }
    var result = values.ToArray();
