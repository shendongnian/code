    public static string Truncate(this string value, int len) {
       if (value.Length <= len) {
           return value;
       }
       return value.Substring(0, len);
    }
    public static string Combine(this string first, string second, int maxLen) {
       return first.Truncate(maxLen - second.Length) + second;
    }
