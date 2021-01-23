    public static class MyStringExtensions
    {
        public static bool ContainsInvariant(this string haystack, char needle)
        {
            return haystack.IndexOf(needle, StringComparison.InvariantCultureIgnoreCase);
        }
    }
