    public static class Extensions
    {
        public IQueryable<T> IsActive<T>(this IQueryable<T> sequence)
            where T : IHaveAActivityPeriod
        {
            return source.Where(item =>
                       item.active &&
                       (item.publishStart <= now) &&
                       (!item.publishEnd.HasValue || (item.publishEnd > now));
        }
    }
