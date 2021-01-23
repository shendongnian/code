    public static class LinqHelper
    {
        // returns an union of an enumerable and a single item
        public static IEnumerable<T> SingleUnion<T>(this IEnumerable<T> source, T item)
        {
            return source.Union(Enumerable.Repeat(item, 1));
        }
    
        // returns an union of two single items
        public static IEnumerable<T> SingleUnion<T>(this T source, T item)
        {
            return Enumerable.Repeat(source, 1).SingleUnion(item);
        }
    }
