    public static bool TryMatch(string input, string pattern, out Match match)
    {
        var m = Regex.Match(input, pattern);
        if(m.Success)
        {
            match = m;
        }
        return m.Success;
    }
    // usage
    string myMatchString = @"a pattern to match"; 
    Match result = null;
    if(TryMatch(somestringinput, myMatchString, out result))
    {
        DoSomething(result.Value);
    }
