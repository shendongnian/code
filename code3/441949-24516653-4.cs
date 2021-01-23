    [Export]
    public class Repository
    {
        private IDbManager _dbManager;
        private readonly IEnumerable<Lazy<IDbManager, IDbManagerMetadata>> DbManagers;
        [ImportingConstructor]
        public Repository([ImportMany(typeof(IDbManager))]IEnumerable<Lazy<IDbManager, IDbManagerMetadata>> dbManagers)
        {
            this.DbManagers = dbManagers;
            var _dbManager = DbManagers.First(x => x.Metadata.DataProvider == DataProvider.Oracle).Value;
        }
        public void Execute()
        {
            var oracleDbManager = DbManagers.First(x => x.Metadata.DataProvider == DataProvider.Oracle).Value;
            
            oracleDbManager.Initialize();
            var sqlDbManager = DbManagers.First(x => x.Metadata.DataProvider == DataProvider.Sql).Value;
            sqlDbManager.Initialize();
        }
    }
