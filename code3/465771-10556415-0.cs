    public SqlCommand GetData(string procedure)
    {
      var conn = new SqlConnection(connectionString);
      var cmd = new SqlCommand(procedure, conn);
      
      cmd.CommandType = CommandType.StoredProcedure;
      conn.Open();
      return cmd;
    }
