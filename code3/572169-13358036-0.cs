    using (SqlConnection cnn = new SqlConnection(_connectionString))
    using (SqlCommand cmd = new SqlCommand())
    {
        cnn.Open();
        cmd.Connection = cnn;
    
        // Example of reading with SqlDataReader
        cmd.CommandText = "select sql query here";
    
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                myList.Add((int)reader[0]);
            }
        }
    
        // Example of updating row
        cmd.CommandText = "update sql query here";
    
        cmd.ExecuteNonQuery();
    }
