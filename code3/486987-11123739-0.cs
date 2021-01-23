    string specialString = "this is silly, string,,not so special''special";
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        using (SqlCommand command = new SqlCommand("Insert into t1 (col1) VALUES (@parame)"))
        {
            command.Connection = conn;
            command.Parameters.AddWithValue("@parame",specialString);
            command.ExecuteNonQuery();
        }
    }
