    public static partial class IDbConnectionExtensionMethods
    {
        public static List<T> Query<T>(this IDbConnection self, string sql, int commandTimeout)
        {
            List<T> results = null;
            self.Exec((dbCmd) =>
                {
                    dbCmd.CommandTimeout = commandTimeout;
                    dbCmd.CommandText = sql;
                    using (var reader = dbCmd.ExecuteReader())
                    {
                        results = reader.ConvertToList<T>();
                    }
                });
            return results;
        }   // eo Query<T>
    }   // eo class IDbConnectionExtensionMethods
