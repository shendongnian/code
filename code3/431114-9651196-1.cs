    public void AddNewUserMethod(string userName)
    {
        SqlConnection connection = new SqlConnection("connection string");
        SqlCommand command = new SqlCommand("AddNewUserProc", connection);
        
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("username", SqlDbType.VarChar, 50).Value = userName;
        
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        finally
        {
            if (connection.State == ConnectionState.Open) { connection.Close(); }
        }
    }
