    public long ParseInt(string str)
    {
        long val = 0;
        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^([\d]+).*$");
        System.Text.RegularExpressions.Match match = reg.Match(str);
        if (match != null) long.TryParse(match.Groups[1].Value, out val);
        return val;
    }
