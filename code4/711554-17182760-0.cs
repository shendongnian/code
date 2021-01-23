    static class StringExtensions
    {
        public static string RemoveLeadingOrTrailingToken(this string value, string token)
        {
            if (value.StartsWith(token))
                return value.Substring(token.Length);
            if (value.EndsWith(token))
                return value.Substring(0, value.IndexOf(token, StringComparison.Ordinal));
            return value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "company";
            string s2 = "product";
            string result = String.Format("{0}-{1}", s1, s2).RemoveLeadingOrTrailingToken("-");
        }    
    }
