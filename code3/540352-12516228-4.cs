    public static class To
    {
        public sealed class ToList { }
        public sealed class ToEnumerable { }
    
        public static readonly ToList List;
        public static readonly ToEnumerable Enumerable;
    
        // C# should target this method when you use "select To.List"
         // inside a query expression.
        public static List<T> Select<T>
            (this IEnumerable<T> source, Func<T, ToList> projector)
        {
            return source.ToList();
        }
    
        // C# should target this method when you use select "To.Enumerable"
        // inside a query expression.
        public static IEnumerable<T> Select<T>
            (this IEnumerable<T> source, Func<T, ToEnumerable> projector)
        {
            return source;
        }
    }
