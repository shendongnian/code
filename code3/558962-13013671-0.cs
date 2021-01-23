    public static class ExtentionClass
    {
        public static string Escape(this string str)
        {
              return str.Replace("\\","\\\\").Replace(",","\\,");
        }
        public static string Unescape(this string str)
        {
              return str.Replace("\\\\","\\").Replace("\\,",",");
        }
    }
