    private void ReplaceIfEmpty(ref string originalValue, string newValue)
    {
      if (string.IsNullOrWhitespace(originalValue))
      {
         originalValue = newValue;
      }
    }
