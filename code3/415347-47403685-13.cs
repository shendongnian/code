    namespace DL.SO.Project.Persistence.Dapper
    {
        public class DapperDbConnectionFactory : IDbConnectionFactory
        {
            private readonly IDictionary<DatabaseConnectionName, string> _connectionDict;
            public DapperDbConnectionFactory(IDictionary<DatabaseConnectionName, string> connectionDict)
            {
                _connectionDict = connectionDict;
            }
            public IDbConnection CreateDbConnection(DatabaseConnectionName connectionName)
            {
                string connectionString = null;
                if (_connectDict.TryGetValue(connectionName, out connectionString))
                {
                    return new SqlConnection(connectionString);
                }
                throw new ArgumentNullException();
            }
        }
    }
