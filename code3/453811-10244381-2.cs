    //using statement to ensure connection is cleaned up correctly
    using (SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=StoreList;Integrated Security=sspi"))
    {
        connection.Open();
        foreach (Match match in matches)
        {
            var command = new SqlCommand("UpdateWordFrequency", connection);
                    
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@word", match.Value));
            command.ExecuteNonQuery();
        }
    }
