    public bool isValidTable(string tableName)
    {
      bool validTable = false;
      string tblQuery =
        string.Format("select case when exists((select * from information_schema.tables where table_name = '{0}')) then 1 else 0 end",
        tableName);
      SqlCeCommand cmd = new SqlCeCommand();
      cmd.CommandText = tblQuery;
      try
      {
        cmd.Connection.Open();
        object objcnt = cmd.ExecuteScalar();
        if ((objcnt != null) && (objcnt != DBNull.Value)) 
        {
          validTable = Int32.Parse(objcnt.ToString()) > 0;
        } 
      }
      finally
      {
        cmd.Connection.Close();
      }
      return validTable;
    }
