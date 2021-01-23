    public SqlCommandWrapper : ISqlCommand
    {
        SqlCommand _sqlCommand;
        public SqlCommandWrapper(String query)
        {
            _sqlCommand = new SqlCommand(query);
        }
        public SqlDataReader ExecuteReader()
        {
            _sqlCommand.ExecuteReader();
        }
    }
