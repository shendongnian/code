    var TestList =
        (from string s in TheString.Split(',')
         let value = TryParseLong(s)
         where value != null
         select value.Value).ToList();
    ...
    static long? TryParseLong(string s)
    {
        long result;
        if (long.TryParse(s, out result))
            return result;
        return null;
    }
