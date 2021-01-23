    public static class StringExtensions
    {
        public static string Rewrite(this string input, string replacement, int index)
        {
            return string.Format("{0}{1}", input.Substring(0, index), replacement);
        }
    }
