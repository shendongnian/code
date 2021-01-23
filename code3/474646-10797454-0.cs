    public static bool Contains(this string source, string value, StringComparison compareMode)
    {
        if (string.IsNullOrEmpty(source))
            return false;
    
        return source.IndexOf(value, compareMode) >= 0;
    }
