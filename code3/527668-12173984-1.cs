    // System.Data.SqlClient.SqlCommand
    // this() does only call _SuppressFinalize
    public SqlCommand(string cmdText, SqlConnection connection) : this()
    {
    	this.CommandText = cmdText;
    	this.Connection = connection;
    }
