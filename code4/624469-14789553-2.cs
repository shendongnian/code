    public static MyOrmLiteExtensions {
        public static string GetTableName<T>(this IDbConnection db) {
            var modelDef = ModelDefinition<T>.Definition;
            return OrmLiteConfig.DialectProvider.GetQuotedTableName(modelDef);
        }
    }
