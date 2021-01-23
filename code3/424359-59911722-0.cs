    public static class Extensions
    {
        public static string Substring2(this string value, int startIndex, int endIndex)
        {
            return value.Substring(startIndex, (endIndex - startIndex + 1));
        }
    }
