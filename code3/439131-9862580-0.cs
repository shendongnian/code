    public static class StringExtensions
    {
      public static string FixSentence(this string instance)
      {
        char[] capitals = Enumerable.Range(65, 26).Select(x => (char)x).ToArray();
        string[] words = instance.Split(capitals);
        string result = string.Join(' ', words);
        return char.ToUpper(result[0]) + result.Substring(1).ToLower();
      }
    }
