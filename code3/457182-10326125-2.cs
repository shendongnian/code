    using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            SqlCommand command = new SqlCommand(
                "SELECT userName from tblUser", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                   // check if reader[0] has the name you are looking for
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
        }
