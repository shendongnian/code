    [Export(typeof(IDbManager))]
    [DbManagerMetadata(DataProvider = DataProvider.Oracle)]
    public sealed class OracleDataProvider : DbManager
    {
        public OracleDataProvider():base(DataProvider.Oracle)
        {
            
        }
    }
