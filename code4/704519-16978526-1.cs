    var record = c.Records.Include(i => i.PlantType).First();
    public static class Extensions
    {
        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> source, Expression<Func<T, TProperty>> path) where T : class
        {
            return System.Data.Entity.DbExtensions.Include(source, path);
        }
    }
