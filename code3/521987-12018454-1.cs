    // Define insert statement with parameters
    string insertStmt = "INSERT INTO dbo.tablename (name, sub_date) VALUES (@name, @mydate)";
    // setup connection and command objects
    using(SqlConnection conn = new SqlConnection("your-connection-string-here"))
    using(SqlCommand cmd = new SqlCommand(insertStmt, conn))
    {
        // add parameters to command
        cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = ".....";
        cmd.Parameters.Add("@mydate", SqlDbType.DateTime).Value = dt;
        // open connection, execute query, close connection
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
