    public static class EnumerableExtensions
    {
        public static string ToCommaSeparatedList<T>(this IEnumerable<T> enumerable)
        {
             return string.Join(",", enumerable.Select(o => o.ToString());
        }
    }
