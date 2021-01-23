    static class Enumerable
    {
        public static string LastNotEmpty(this IEnumerable<string> source) 
        {
            return source.LastOrDefault(x=>!string.isNullOrEmpty(x));
        }
    }
