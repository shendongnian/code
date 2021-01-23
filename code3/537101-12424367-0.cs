    protected IEnumerable<T> FetchData<T>(Func<IDataReader, T> processor, String query)
    {
        using (var connection = CreateConnection())
        {
            connection.ConnectionString = ConnectionString;
            connection.Open();
    
            using (var command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = query;
    
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.read())
                    {
                        yield return processor(reader);
                    }
                }
            }
        }
    }
