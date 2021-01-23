    using (SqlConnection conn = new SqlConnection("connection string"))
    {
        conn.Open();
        SqlCommand command = new SqlCommand()
        {
            CommandText = "dbo.sample_proc",
            Connection = conn,
            CommandType = CommandType.StoredProcedure
        };
        if (condition1)
            command.Parameters.Add(new SqlParameter("Condition1", condition1Value));
        if (condition2)
            command.Parameters.Add(new SqlParameter("Condition2", condition2Value));
        if (condition3)
            command.Parameters.Add(new SqlParameter("Condition3", condition3Value));
        IDataReader reader = command.ExecuteReader();
        while(reader.Read())
        {
        }
        conn.Close();
    }
