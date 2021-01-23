    public static MyOrmLiteExtensions {
        public static string GetTableName<T>(this IDbConnection db) {
            var modelDef = ModelDefinition<User>.Definition;
            return OrmLiteConfig.DialectProvider.GetQuotedTableName(modelDef);
        }
    }
