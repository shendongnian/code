    public static class Extensions
    {
        public static bool Like(this string s, string pattern, RegexOptions options = RegexOptions.IgnoreCase)
        {
            return Regex.IsMatch(s, pattern, options);
        }
    }
