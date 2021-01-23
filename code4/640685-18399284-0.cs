    public static partial class IDbConnectionExtensionMethods
    {
        public static List<T> Query<T>(this IDbConnection self, string sql, TimeSpan commandTimeout)
        {
            List<T> results = null;
            self.Exec((dbCmd) =>
                {
                    dbCmd.CommandTimeout = (int)commandTimeout.TotalSeconds;
                    dbCmd.CommandText = sql;
                    using (var reader = dbCmd.ExecuteReader())
                    {
                        results = reader.ConvertToList<T>();
                    }
                });
            return results;
        }   // eo Query<T>
    }   // eo class IDbConnectionExtensionMethods
