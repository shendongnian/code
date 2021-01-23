    private string ReplaceIfEmpty(string originalValue, string newValue)
    {
       if (string.IsNullOrWhitespace(originalValue))
       {
          originalValue = newValue;
       }
       return originalValue;
    }
