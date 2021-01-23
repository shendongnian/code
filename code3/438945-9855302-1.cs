    public static class StringExtensions
    {
      private string NormalizeText(string text)
      {
        return text..Replace("_","")
                    .Replace(" ","")
                    .Replace(",","");
      }
 
      public static bool CustomEquals(this string instance, string otherString)
      {
        return NormalizeText(instance).Equals(NormalizeText(otherString),
                                              StringComparison.CurrentCultureIgnoreCase);
      }
    }
