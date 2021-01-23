    public static class LinqExtensions
    {
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> query, T item)
        {
            return new[] { item }.Concat(query);
        }
    }
