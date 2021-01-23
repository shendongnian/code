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
