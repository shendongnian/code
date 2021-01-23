    Use string extension method to remove white space from any place in a string.
    
    public static string RemoveWhiteSpaces(this string input)
    
    {
      return Regex.Replace(input, @"\s+", "");
    }
