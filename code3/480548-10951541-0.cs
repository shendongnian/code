    using (SqlConnection connection = new SqlConnection("DataSource=..."))
    using (SqlComamnd command = connection.CreateCommand())
    {
        command.CommandText = "INSERT INTO ...";
    
        connection.Open();
        int i = command.ExecuteNonQuery(); // number of rows inserted
    }
