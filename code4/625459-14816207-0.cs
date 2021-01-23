    // initialize UID value and SQL query with parameter placeholder
    int uid = 12;
    sql = "SELECT [Something] FROM [Person] WHERE [person_uid] = @UID";
    // initialize connection and open
    using (SqlConnection connection = new SqlConnection("<connection string>")
    {     
        SqlCommand command = new SqlCommand(sql, connection)
        // add UID parameter
        command.Parameters.Add(new SqlParameter("UID", uid);
        try
        {
            connection.Open();        
            // execute and read results
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                // process results        
            }
        }
        catch (Exception ex)
        {
            // handle exceptions
        }
    }
