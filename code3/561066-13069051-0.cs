    public static class StringExtensions
    {
        public static string Quotify(this string s)
        {
            return string.Format("\"{0}\"", s);
        }
    }
