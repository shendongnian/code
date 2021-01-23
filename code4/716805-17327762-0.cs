    using (SqlConnection conn = new SqlConnection("conn string"))
    {
        conn.Open();
        SqlCommand command = new SqlCommand()
        {
            CommandText = "command text",
            Connection = conn,
            CommandType = CommandType.StoredProcedure //could be non-stored proc.. but would reccomend stored proc assuming SQL Server
        };
        command.Parameters.Add(new SqlParameter("MyParam", "param1"));
        command.Parameters.Add(new SqlParameter("MyParam2", "param2"));
        IDataReader reader = command.ExecuteReader();
        while(reader.Read())
        {
         //magic here
        }
        conn.Close();
    }
