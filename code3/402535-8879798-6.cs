    public static class MyStringExtensions
    {
        public static bool ContainsAnyCaseInvariant(this string haystack, char needle)
        {
            return haystack.IndexOf(needle, StringComparison.InvariantCultureIgnoreCase);
        }
        
        public static bool ContainsAnyCase(this string haystack, char needle)
        {
            return haystack.IndexOf(needle, StringComparison.CurrentCultureIgnoreCase);
        }
    }
