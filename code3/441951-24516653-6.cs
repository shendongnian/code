cs
public enum DataProvider
{
    Oracle,
    Sql,
}
[InheritedExport]
public interface IDbManager
{
    void Initialize();
}
[InheritedExport(typeof(IDbManager))]
public class DbManager : IDbManager
{
    public DbManager(DataProvider providerType)
    {
        _providerType = providerType;
    }
    public void Initialize()
    {
        Console.WriteLine("provider : {0}", _providerType);
    }
    public DataProvider _providerType { get; set; }
}
And Two different Implementations
    [Export(typeof(IDbManager))]
    [DbManagerMetadata(DataProvider = DataProvider.Oracle)]
    public sealed class OracleDataProvider : DbManager
    {
        public OracleDataProvider():base(DataProvider.Oracle)
        {
            
        }
    }
And 
    [Export(typeof(IDbManager))]
    [DbManagerMetadata(DataProvider = DataProvider.Sql)]
    public sealed class SqlDataProvider : DbManager
    {
        public SqlDataProvider()
            : base(DataProvider.Sql)
        {
        }
    }
And you can decide which one to use by using Metadata interface we created in first step as in repository shown below
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
