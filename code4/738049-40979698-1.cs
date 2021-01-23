    public static string RemoveWhiteSpaces(this string input)
    
    {
      return Regex.Replace(input, @"\s+", "");
    }
