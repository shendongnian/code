    public static DataTable GetData()
    {
      using (IDbConnection Connection = GetConnection("SiteSqlServer"))
      {
        IDbCommand Command = Connection.CreateCommand();
        Command.CommandText = "DummyCommand";
        Command.CommandType = CommandType.StoredProcedure;
    
        Connection.Open();
    
        using (IDataReader reader = Command.ExecuteReader())
        {
          DataTable Result = new DataTable();
          Result.Load(reader);
          return Result;
        }
      }
    }
