    [SqlFunction(DataAccess = DataAccessKind.Read, IsDeterministic = true)]
    public static string Replace(string input, string pattern, string replacement, int options)
    {
        return Regex.Replace(input, pattern, replacement, (RegexOptions)options);
    }
