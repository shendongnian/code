    public static class To
    {
        public sealed class ToList { }
    
        public static readonly ToList List;
    
        // C# should target this method when you use "select To.List"
        // inside a query expression.
        public static List<T> Select<T>
            (this IEnumerable<T> source, Func<T, ToList> projector)
        {
            return source.ToList();
        }
    }
    
    public static class As
    {
        public sealed class AsEnumerable { }
    
        public static readonly AsEnumerable Enumerable;
    
        // C# should target this method when you use "select As.Enumerable"
        // inside a query expression.
        public static IEnumerable<T> Select<T>
            (this IEnumerable<T> source, Func<T, AsEnumerable> projector)
        {
            return source;
        }
    }
