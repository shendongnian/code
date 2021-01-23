    public static List<T> GetUnshippedOrders<T>(string server,string port,string database,string username,string password, string orderStatus, Func<IDataReader, T> factoryMethod)
      {
            var results = new List<T>();
            using (var conn = ConnectToMySql(server, port, database, username, password))
            {            
               using (var command = new MySqlCommand("SELECT OrderNumber FROM orders WHERE OrderStatus = @orderStatus;", conn))
                {
                   command.Parameters.AddWithValue("@orderStatus", orderStatus);
                   using (var reader = command.ExecuteReader())
                   {
                     while (reader.Read())
                     {
                       results.Add(factoryMethod(reader)); 
                     }
                   }
                 }
            } 
            return results;
       }
