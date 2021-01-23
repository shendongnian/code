    List<string> list = new List<string>();
    string pattern = "{{(.*?)}}";
    
    Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
    Match m = r.Match(text);
    
    while (m.Success)
    {
        list.Add(m.Groups[1].Value);
    
        m = m.NextMatch();
    }
    
    return list;
