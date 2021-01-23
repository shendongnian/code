    static class Extensions
    {
        public static void SetCommandTimeout(this IObjectContextAdapter db, TimeSpan? timeout)
        {
            db.ObjectContext.CommandTimeout = timeout.HasValue ? (int?) timeout.Value.TotalSeconds : null;
        }
    }
