    public static class StringExtensions
    {
        public static string AddSuffix(this string value, string suffix)
        {
            return value.EndsWith(suffix) ? value : value + suffix;
        }
    }
