    private bool Set(string stream, string inputdata) 
    {
        var regex = BuildRegex(stream);
        bool retval = regex.IsMatch(inputdata);
        return retval;
    }
    static Dictionary<string, Regex> regexCache = new Dictionary<string, Regex>();
    private static Regex BuildRegex(string pattern)
    {
        Regex exp;
        if (!regexCache.TryGetValue(pattern, out exp))
        {
            exp = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            regexCache.Add(pattern, exp);
        }
        return exp;
    }
