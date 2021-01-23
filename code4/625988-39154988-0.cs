    public static string RegexReplace(this string source, string pattern, string replacement)
    {
      return Regex.Replace(source,pattern, replacement);
    }
    public static string RemoveEnd(this string source, string value)
    {
      return RegexReplace(source, $"{value}$", string.Empty);
    }
