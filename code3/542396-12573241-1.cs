    private List<int> ReadOrderData()
    {
        return ExecuteList<int>("SELECT OrderID FROM dbo.Orders;", 
            x => x.GetInt32("orderId")).ToList();
    }
    private IEnumerable<T> ExecuteList(string query, 
        Func<IDataRecord, T> entityCreator)
    {
        using(var connection = CreateConnection())
        using(var command = connection.CreateCommand())
        {
            command.CommandText = query;
            connection.Open();
            using(var reader = command.ExecuteReader())
            {
                while(reader.Read()) 
                   yield return entityCreator(reader);
            }
        }
    }
