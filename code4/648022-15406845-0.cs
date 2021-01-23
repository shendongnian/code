    using (var connection = SQLiteFactory.Instance.CreateConnection())
    {
      Debug.Assert(connection != null, "connection != null");
      connection.ConnectionString = connectionString;
      connection.Open();
    
      try
      {
        using (var command = connection.CreateCommand())
        {
          // Execute connection
        }
      }
      finally
      {
        connection.Close();
      }
    }
