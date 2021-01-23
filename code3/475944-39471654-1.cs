    static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<T>> ToPages<T>(this IEnumerable<T> elements, int pageSize)
        {
            if (elements == null)
                throw new ArgumentNullException("elements");
            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException("pageSize","Must be greater than 0!");
    
            int i = 0;
            var paged = elements.GroupBy(p => i++ / pageSize);
            return paged;
        }
    }
