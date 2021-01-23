    // define connection and command object
    using(SqlConnection conn = new SqlConnection("your-connection-string-here"))
    using(SqlCommand cmd = new SqlCommand("dbo.TVP_PROC", conn))
    {
       // define the command to be a stored procedure
       cmd.CommandType = CommandType.StoredProcedure;
       
       // set up parameters
       cmd.Parameters.Add("@ID", SqlDbType.Structured).Value = datatable;
       
       // open connection, execute stored procedure, close connection
       conn.Open();
       cmd.ExecuteNonQuery();
       conn.Close();
    }
