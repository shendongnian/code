    private string Expand(string text)
    {
        var rx = new Regex(@"(\d)\((.*?)\),");
        var s = rx.Replace(text, m => String.Concat(Enumerable.Repeat(m.Groups[2].Value + ",", Convert.ToInt32(m.Groups[1].Value))));
    
        if (rx.IsMatch(s))
            return Expand(s);
    
        return s;
    }
