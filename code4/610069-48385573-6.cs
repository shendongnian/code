    public static class IEnumerableExtensions
    {
        public static IEnumerable<TKey> GetNonNull<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey?> keySelector) 
            where TKey : struct
        {
            return source.Select(keySelector)
                .Where(x => x.HasValue)
                .Select(x => x.Value);
        }
         
        // the two following are not needed for your example, but are handy shortcuts to be able to write : 
        // myListOfThings.GetNonNull()
        // whether myListOfThings is List<SomeClass> or List<int?> etc...
        public static IEnumerable<T> GetNonNull<T>(this IEnumerable<T?> source) where T : struct
        {
            return GetNonNull(source, x => x);
        }
        public static IEnumerable<T> GetNonNull<T>(this IEnumerable<T> source) where T : class
        {
            return GetNonNull(source, x => x);
        }
    }
