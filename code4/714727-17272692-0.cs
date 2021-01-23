    bool isReserved;
    using (SqlConnection connection = new SqlConnection(connectionString)
    using (SqlCommand command = new SqlCommand("SELECT isReserved FROM YourTable WHERE BookingId = 1", connection))
    {
        connection.Open();  
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                isReserved = (bool)reader["isReserved"];
            }
        }
    }
