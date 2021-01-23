        public static IQueryable<T> Filter<T>(this IQueryable<T> collection, IEnumerable<Expression<Func<T, bool>>> filters)
        {
            var results = collection;
            foreach (var f in filters)
            {
                results = results.Where(f);
            }
            return results;
        }
