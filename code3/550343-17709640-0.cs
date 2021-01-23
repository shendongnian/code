dm.Context.SetCommandTimeout(120).Database.SqlQuery...
    public static class EF
    {
        public static DbContext SetCommandTimeout(this DbContext db, TimeSpan? timeout)
        {
            ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = timeout.HasValue ? (int?) timeout.Value.TotalSeconds : null;
            return db;
        }
        public static DbContext SetCommandTimeout(this DbContext db, int seconds)
        {
            return db.SetCommandTimeout(TimeSpan.FromSeconds(seconds));
        } 
    }
