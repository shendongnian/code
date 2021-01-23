    public static class MyStringExtensions
    {
        public static bool ContainsAnyCaseInvariant(this string haystack, char needle)
        {
            return haystack.IndexOf(needle, StringComparison.InvariantCultureIgnoreCase) != -1;
        }
        
        public static bool ContainsAnyCase(this string haystack, char needle)
        {
            return haystack.IndexOf(needle, StringComparison.CurrentCultureIgnoreCase) != -1;
        }
    }
