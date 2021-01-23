    public static class Helpers
    {
        public static string FirstOrEmpty(this IEnumerable<string> source)
        {
            return source.FirstOrDefault() ?? string.Empty;
        }
    }
