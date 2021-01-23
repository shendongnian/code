    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandText = "SELECT ClientID FROM dbo.Filelist WHERE ToAccountName = @param"; // note single column in select clause
        command.Parameters.AddWithValue("@param", output[0]); // note parameterized query
    
        connection.Open();
        using (SqlDataReader reader = command.ExecuteReader())
        {  
            while (reader.Read()) // reader.HasRow is doubtfully necessary
            {
                // logic goes here
                // but it's better to perform it on data layer too
                // or return all clients first, then perform client-side logic
                yield return reader.GetString(0);
            }
        } // note that using block calls Dispose()/Close() automatically
    }
