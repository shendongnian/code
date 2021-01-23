    public static string FirstFromSplit(this string source, char delimiter)
    {
        var i = input.IndexOf(delimiter);
        
        return i == -1 ? input : input.Substring(0, i);
    }
    public static string FirstFromSplit(this string source, string delimiter)
    {
        var i = input.IndexOf(delimiter);
        
        return i == -1 ? input : input.Substring(0, i);
    }
