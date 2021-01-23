    public static class StringExtensions
    {
        public static SubstringUpTo(this string str, int length)
        {
            int maxLength = Math.Min(str.Length, length);
            return str.Substring(0, maxLength);
        }
    }
