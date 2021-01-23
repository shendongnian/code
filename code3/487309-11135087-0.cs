    using (var connection = new SharePointConnection(connectionString))
    {
        connection.Open();
        using (var command = new SharePointCommand(@"SELECT Customer.name AS Name
                    , Customer.address AS Address
                    , Customer.ID AS CustomerId
                    , Product.ID AS ProductId
                    , Product.customer_id AS ProductCustomerId
                    , Product.productname AS ProductName
                    FROM Customers
                    INNER JOIN Log ON CustomerId = ProductCustomerId"
                    , connection))
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["Name"].ToString().PadRight(30) + " : " + reader["Event"].ToString().PadRight(30) + " : " + reader["Created"].ToString());
                }
            }
        }
    }
