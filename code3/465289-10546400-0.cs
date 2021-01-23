    string input = "45##78$$#56$$JK01UU", pattern = "##";
    Regex rx = new Regex(pattern);
    var indices = new List<int>();
    var matches = rx.Matches(s);
    for (int i=0 ; i<matches.Length ; i++)
    {
        indices.Add(matches[i].Index);
    }
