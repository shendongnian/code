    public static class StringExtensions
    {
       public static string TrimWhere(this string s)
       {
          if (String.IsNullOrEmpty(s))
              return s;
    
          return Regex.Replace(s, @"where\s*\Z", "", RegexOptions.IgnoreCase).Trim();
       }
    }
