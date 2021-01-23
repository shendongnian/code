    public SqlCommandWrapper : ISqlCommand
    {
        SqlCommand _sqlCommand;
        public SqlCommandWrapper(string query)
        {
            _sqlCommand = new SqlCommand(query);
        }
        public SqlDataReader ExecuteReader()
        {
            _sqlCommand.ExecuteReader();
        }
    }
