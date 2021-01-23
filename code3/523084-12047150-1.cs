    public static T[] ToArray<T>(this string s, Func<string, T> convert, char[] seps)
    {
      char[] separators = seps != null && seps.Length > 0 ? seps : new[] { ',' };
      T[]    values     = s.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                           .Select(x => convert(x))
                           .ToArray()
                           ;
      return values;
    }
