    public static class StringExtender
    {
      static readonly string[] validBooleanStrings = { "True", "False", "Yes", "No" };
      public static bool IsValidBooleanString(this string value)
      {
        return ValidBooleanStrings.Contains(value, StringComparer.OrdinalIgnoreCase);
      }
    }
