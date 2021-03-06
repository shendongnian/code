    string queryString =
        "SELECT OrderID, CustomerID FROM dbo.Orders;";
    using (SqlConnection connection =
               new SqlConnection(connectionString))
    {
        SqlCommand command =
            new SqlCommand(queryString, connection);
        connection.Open();
        // here is your SqlDataReader that implements IDataReader
        SqlDataReader reader = command.ExecuteReader();
        // Call Read before accessing data.
        while (reader.Read())
        {
            Console.WriteLine(String.Format("{0}, {1}",
                reader[0], reader[1]));
        }
        // Call Close when done reading.
        reader.Close();
    }
