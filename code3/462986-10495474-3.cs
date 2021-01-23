    public static class IQueryOverExtension
    {
        public static IQueryOver<T, T> CombinedWhere<T>(this IQueryOver<T, T> source, params Expression<Func<T, bool>>[] predicates)
        {
            return predicates.Aggregate(source, (current, predicate) => current.Where(predicate));
        }
    }
