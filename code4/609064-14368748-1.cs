    static SqlConnection InitializeDatabase(string connectionString)
    {
      var connection = new SqlConnection(connectionString);
      connection.Open();
      return connection;
    }
