    public int GetProductPrice(string productName)
    {
        // Quite possibly extract the connection creation into a separate method
        // to call here.
        using (var conn = new SqlConnection(...))
        {
            conn.Open();
            using (var command = new SqlCommand(
                "SELECT ProductPrice FROM Products WHERE ProductName = @ProductName",
                conn))
            {
                command.AddParameter("@ProductName", SqlDbType.VarChar)
                       .Value = productName;
                object price = command.ExecuteScalar();
                // And you'd do the casting here
            }
        }
    }
