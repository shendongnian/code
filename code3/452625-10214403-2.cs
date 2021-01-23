    using(SqlConnection conn = new SqlConnection(connString))
    {
        conn.Open();
    
        SqlCommand command = new SqlCommand(sql, conn);
        command.CommandType = CommandType.Text;
    
        // Assign the value projectid to the parameter @projectid
        command.Parameters.Add(new SqlParameter("@projectid", projectid));
    
        // Execute The Command (fill dataset, create datareader, etc...)
        SqlDataReader reader = command.ExecuteReader();
    }
