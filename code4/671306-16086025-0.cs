    private DataTable Get(string strProductID, string connStr) {
      var table = new DataTable();
      string cmdText = "SELECT * FROM Products WHERE strProductID=@strProductID";
      using (var cmd = new SqlCeCommand(cmdText, new SqlCeConnection(connStr))) {
        cmd.Parameters.Add("@strProductID", SqlDbType.NVarChar, 50).Value = strProductID;
        cmd.Connection.Open();
        table.Load(cmd.ExecuteReader());
        cmd.Connection.Close();
      }
      return table;
    }
