    [Export(typeof(IDbManager))]
    [DbManagerMetadata(DataProvider = DataProvider.Sql)]
    public sealed class SqlDataProvider : DbManager
    {
        public SqlDataProvider()
            : base(DataProvider.Sql)
        {
        }
    }
