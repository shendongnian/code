    public interface IDatabase
    {
        string ConnectionString { get; set; }
        IDataReader ExecuteSql(string sql);
    }
