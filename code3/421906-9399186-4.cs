    public static string ReplaceIfEmpty(this string originalValue, 
                                        string replaceValue)
    {
       if (string.IsNullOrWhitespace(originalValue))
          return replaceValue;
       else
          return originalValue;
    }
