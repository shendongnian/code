    public static class StringExtensions
    {
        public static string Truncate(this string str, int length)
        {
            if(length < 0)
            {
                throw new ArgumentOutOfRangeException("Length must be >= 0");
            }
            if (str == null)
            {
                return null;
            }
            int maxLength = Math.Min(str.Length, length);
            return str.Substring(0, maxLength);
        }
    }
