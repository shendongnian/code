    public class DataBase
    {
        private static string DEFAULT_CONNECTION_STRING = "*your connection string*";
        private string connectionString;
        private DbProviderFactory factory;
	
        public DataBase()
        {
                connectionString = DEFAULT_CONNECTION_STRING;
                factory = DbProviderFactories.GetFactory("MySql.Data.MySql");
        }
	
        public IDataReader GetData(string sql)
        {
                using(var conn = factory.CreateConnection())
                using(var command = factory.CreateCommand())
                {
                        command.CommandText = sql;
                        command.CommandType = CommandType.Text;
                        conn.ConnectionString = this.connectionString;
                        conn.Open();
                        command.Connection = conn;
                        return cmd.ExecuteReader();
                }
        }
    }
