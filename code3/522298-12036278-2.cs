    public static class StringExtensions
    {
      public static bool IsNotNullAndNotWhiteSpaceAnd(this string s, Func<string, bool> func)
      {
        if (string.IsNullOrWhiteSpace(s))
        {
          return false;
        }
        return func(s);
      }
    }
