    public static class To
    {
        public sealed class ToList { }
        public sealed class ToEnumerable { }
    
        public static readonly ToList List;
        public static readonly ToEnumerable Enumerable;
    
        public static List<T> Select<T>
            (this IQueryable<T> source, Func<T, ToList> projector)
        {
            return source.ToList();
        }
    
        public static IEnumerable<T> Select<T>
            (this IQueryable<T> source, Func<T, ToEnumerable> projector)
        {
            return source.AsEnumerable();
        }
    }
