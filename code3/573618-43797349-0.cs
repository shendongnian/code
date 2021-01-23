    public static string ReplaceSingleQuote(this string s) {
      if (!string.IsNullOrEmpty(s))
        return s.Replace('\u0027', '\u2032');
      else
        return s;
    }
