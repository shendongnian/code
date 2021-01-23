    public class SQL : IDatabase
    {
        private string m_ConnectionString = string.Empty;
        public string ConnectionString
        {
            get { return m_ConnectionString; }
            set { m_ConnectionString = value; }
        }
        public IDataReader ExecuteSql(string sql)
        {
            using (var command = new SqlCommand(sql, new SqlConnection(ConnectionString)) { CommandType = CommandType.Text, CommandText = sql, CommandTimeout = 0 })
            {
                if (command.Connection.State != ConnectionState.Open) command.Connection.Open();
                return command.ExecuteReader();
            }
        }
    }
