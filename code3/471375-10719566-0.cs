    public class SqlConnect
    {
        public string ConnectionString { get; private set; }
        public string CommandText { get; private set; }
        public SqlParameterCollection Parameters { get; private set; }
        public SqlConnect(string connectionString, string commandText)
        {
            ConnectionString = connectionString;
            CommandText = commandText;
            Parameters = null;
        }
        public SqlConnect(string connectionString, string commandText, SqlParameterCollection parameters)
            : this(connectionString, commandText)
        {
            Parameters = parameters;
        }
        public int Execute()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = CommandText;
                foreach (var sqlParameter in Parameters)
                {
                    command.Parameters.Add(sqlParameter);
                }
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
                return rowsAffected;
            }
        }
    }
