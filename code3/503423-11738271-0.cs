    public static class StringExtensions
    {
      public static string ToUpperFirstLetter(this object val)
      {
        string str = val as string;
        if (string.IsNullOrWhitespace(str)) return str;
        
        return str.Substring(0, 1).ToUpper() + str.Substring(1);
      }
    }
    public static class ExpandoObjectExtensions
    {
      public static bool HasValue(this object val, string key)
      {
        var expando = val as ExpandoObject;
        if (expando == null) return false;
        
        return ((IDictionary<string, object>)expando).ContainsKey(key);
      }
    }
