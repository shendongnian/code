    public bool isValidTable(string tableName)
    {
      bool validTable = false;
      string tblQuery =
        string.Format("select * from information_schema.tables where table_name='{0}'",
        tableName);
      SqlCeCommand cmd = new SqlCeCommand();
      cmd.CommandText = tblQuery;
      try
      {
        cmd.Connection.Open();
        // I don't know if this works because I don't have .NET 1.1
        SqlCeDataReader r = cmd.ExecuteReader();
        validTable = r.Read();
      }
      finally
      {
        cmd.Connection.Close();
      }
      return validTable;
    }
