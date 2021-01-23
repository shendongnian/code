    public static string FirstFromSplit(this string source, char delimiter)
    {
        var i = source.IndexOf(delimiter);
        
        return i == -1 ? source : source.Substring(0, i);
    }
    public static string FirstFromSplit(this string source, string delimiter)
    {
        var i = source.IndexOf(delimiter);
        
        return i == -1 ? source : source.Substring(0, i);
    }
