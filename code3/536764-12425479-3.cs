    internal static class TableBuilderExtentions
    {
        internal static TableBuilder<TColumns> Sql<TColumns>(
            this TableBuilder<TColumns> tableBuilder,
            Func<string, string> sql,
            bool suppressTransaction = false,
            object anonymousArguments = null)
        {
            string sqlStatement = sql(tableBuilder.GetTableName());
            DbMigration dbMigration = tableBuilder.GetDbMigration();
            Action<string, bool, object> executeSql = dbMigration.GetSqlMethod();
            executeSql(sqlStatement, suppressTransaction, anonymousArguments);
            return tableBuilder;
        }
        [Pure]
        private static DbMigration GetDbMigration<TColumns>(this TableBuilder<TColumns> tableBuilder)
        {
            var field = tableBuilder.GetType().GetField(
                "_migration", BindingFlags.NonPublic | BindingFlags.Instance);
            return (DbMigration)field.GetValue(tableBuilder);
        }
        /// <summary>
        ///   Caution: This implementation only works on single properties.
        ///   Also, coder may have specified the 'name' parameter which would make this invalid.
        /// </summary>
        private static string GetPropertyName<TColumns>(Expression<Func<TColumns, object>> someObject)
        {
            MemberExpression e = (MemberExpression)someObject.Body;
            return e.Member.Name;
        }
        [Pure]
        private static Action<string, bool, object> GetSqlMethod(this DbMigration migration)
        {
            MethodInfo methodInfo = typeof(DbMigration).GetMethod(
                "Sql", BindingFlags.NonPublic | BindingFlags.Instance);
            return (s, b, arg3) => methodInfo.Invoke(migration, new[] { s, b, arg3 });
        }
        [Pure]
        private static string GetTableName<TColumns>(this TableBuilder<TColumns> tableBuilder)
        {
            var field = tableBuilder.GetType().GetField(
                "_createTableOperation", BindingFlags.NonPublic | BindingFlags.Instance);
            var createTableOperation = (CreateTableOperation)field.GetValue(tableBuilder);
            return createTableOperation.Name;
        }
    }
