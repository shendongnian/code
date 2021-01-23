    public static class StringExtensions {
      public static string Replace(this string str, string match, string replacement, StringComparison comparison) {
        int index = 0, newIndex;
        StringBuilder result = new StringBuilder();
        while ((newIndex = str.IndexOf(match, index, comparison)) != -1) {
          result.Append(str.Substring(index, newIndex - index)).Append(replacement);
          index = newIndex + match.Length;
        }
        return index > 0 ? result.Append(str.Substring(index)).ToString() : str;
      }
    }
