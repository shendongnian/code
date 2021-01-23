    void string Matcher(Match m)
    {
        if (m.Groups.Length < 3)
        {
            return m.Value;
        }
    
        return string.Join("",  m.Groups
                                 .Select((g, i) => i == 2 ? "replacedText" : g.Value)
                                 .Skip(1) //for Groups[0]
                                 .ToArray());
    }
