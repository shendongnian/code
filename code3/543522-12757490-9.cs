    public SqlConnection GetOpenConnection()
    {
    	_sqlConnection = new SqlConnection(_dbConnectionString); 
    	_sqlConnection.Open();
    	return _sqlConnection;
    }
