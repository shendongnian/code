    private static string _connectionString = string.Empty;
    private static string connectionString
    {
      get
      {
        if (string.IsNullOrEmpty(_connectionString))
        {
          _connectionString = new SqlConnectionStringBuilder
          {
            DataSource = DB_SOURCE,
            InitialCatalog = DB_NAME,
            Encrypt = false,
            TrustServerCertificate = false,
            UserID = DB_USER,
            Password = DB_PASS,
          }.ToString();
        }
        return _connectionString;
      }
    }
    public static void execute(String query)
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      using (SqlCommand command = new SqlCommand(query, connection))
      {
        connection.Open();
        command.ExecuteNonQuery();
      }
    }
