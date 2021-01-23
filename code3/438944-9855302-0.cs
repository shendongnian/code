    public static class StringExtensions
    {
      public static bool CustomEquals(this string instance, string otherString)
      {
        return instance.Replace("_","")
                       .Replace(" ","")
                       .Replace(",","")
                       .Equals(otherString.Replace("_","")
                                          .Replace(" ",""),
                                          .Replace(",",""),
                               StringComparison.CurrentCultureIgnoreCase);
      }
    }
