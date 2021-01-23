    // set up connection and command
    using (SqlConnection conn = new SqlConnection("your-connection-string-here"))
    using (SqlCommand cmd = new SqlCommand("dbo.DoesTableExist", conn))
    {
        // define command to be stored procedure
        cmd.CommandType = CommandType.StoredProcedure;
        
        // add parameter
        cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 100).Value = "your-table-name-here";
        
        // open connection, execute command, close connection
        conn.Open();
        int result = (int)cmd.ExecuteScalar();
        conn.Close();
    }
