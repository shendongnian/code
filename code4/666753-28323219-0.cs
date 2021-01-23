    public static class StringExtensions
    {
        public static string Ellipsis(this string s, int charsToDisplay)
        {
            if (!string.IsNullOrWhiteSpace(s))
                return s.Length <= charsToDisplay ? s : new string(s.Take(charsToDisplay).ToArray()) + "...";
            return String.Empty;
        }
    }
