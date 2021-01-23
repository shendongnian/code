    public static class LinqExtensions
    {
        public static IEnumerable<T> WithDistinctProperty<T>(this IEnumerable<T> source, string propertyName)
        {
            return source.Distinct(new PropertyComparer<T>(propertyName));
        }
    }
