    public static class IHasActiveExtensions
    {
        public static IQueryable<T> ExcludeInactive<T>(this IQueryable<T> query)
            where T : IHasActive
        {
            return query.Where(m => m.Active);
        }
    }
