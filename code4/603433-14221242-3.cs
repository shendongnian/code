    public static class Extensions
    {
        public IQueryable<T> Active<T>(this IQueryable<T> source)
            where T : YourEntityType
        {
            return source.Where(a => ((a.publishEnd > DateTime.Now) || (a.publishEnd == null))
                              && ((a.publishStart <= DateTime.Now) || (a.publishStart == null))
                              && a.active == true);
        }
    }
