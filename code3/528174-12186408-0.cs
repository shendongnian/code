        string connectionString = ....; //adjust your connection string
        string queryString = "INSERT INTO ....;"; //Adjust your query
        using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            using( SqlCommand command = new SqlCommand(
                queryString, connection))
            {
            connection.Open();
            command .ExecuteNonQuery();
           }
        }
