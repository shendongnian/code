    public static string RegexReplace(this string source, string pattern, string replacement)
    {
      return Regex.Replace(source,pattern, replacement);
    }
    
    public static string ReplaceEnd(this string source, string value, string replacement)
    {
      return RegexReplace(source, $"{value}$", replacement);
    }
    
    public static string RemoveEnd(this string source, string value)
    {
      return ReplaceEnd(source, value, string.Empty);
    }
