    public static List<T> GetUnshippedOrders<T>(string server,string port,string database,string username,string password, string orderStatus) where T : class
    {
        var orderNumbers = new List<T>();
        using (var conn = ConnectToMySql(server, port, database, username, password))
        {            
           var command = new MySqlCommand("SELECT OrderNumber FROM orders WHERE OrderStatus = @orderStatus;", conn);
            command.Parameters.AddWithValue("@orderStatus", orderStatus);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                orderNumbers.Add((T)(reader[0])); 
            }
        } 
        return orderNumbers;
    }
