    public class SqlServerRestorerExstension : SQLServerRestorer
    {
        public SqlServerRestorerExstension(string dbServer, string dbName, string dbFilePath, string dbDataFileName, string dbLogFileName, bool detachOnFixtureTearDown, string connectionstring) : base(dbServer, dbName, dbFilePath, dbDataFileName, dbLogFileName, detachOnFixtureTearDown)
        {
            ConnectionString = connectionstring;
        }
    
        public new string ConnectionString { get; private set; }
    }
