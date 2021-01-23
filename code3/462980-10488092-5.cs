    public static class MyExtensions
    {
        // usage:
        // myList.CombinedWhere(x => x.Name == "John", x => x.City == "Miami", x => x.Code > 5);
        public static IEnumerable<T> CombinedWhere<T>(this IEnumerable<T> source,
            params Func<T, bool>[] predicates)
        {
            var query = source.Where(l => true);
            foreach(var pred in predicates)
            {
                query = query.Where (pred);
            }
            return query;
        }
    }
