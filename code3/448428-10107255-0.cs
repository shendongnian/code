    public static class StringExtensions
    {
        public static string TrimNull(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? value : value.Trim();
        }
    }
