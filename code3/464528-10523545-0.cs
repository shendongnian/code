    public static class MyExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return (source == null || !source.Any());
        }
    }
