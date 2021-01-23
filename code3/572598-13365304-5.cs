    static class MyEnumerable
    {
        public static string LastNotEmpty(this IEnumerable<string> source) 
        {
            return source.LastOrDefault(x=>!string.isNullOrEmpty(x));
        }
    }
