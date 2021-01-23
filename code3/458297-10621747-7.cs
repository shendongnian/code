    sqlQuery = "SELECT `ID` from `users` WHERE `CallerName`=?";
    int result = 0;
    OleDbConnection conn = new OleDbConnection(connectionString);
    try {
      conn.Open();
      var cmd = new OleDbCommand(sqlQuery, conn);
      //cmd.CommandText = sqlQuery; This command was specified by your initializer
      cmd.Parameters.Add("?", OleDbType.VarChar, 255).Value = labelProblemDate.Text.Trim();
      //cmd.Parameters["@CallerName"].Value = name; Possible bug here
      using (OleDbDataReader reader = cmd.ExecuteReader())
      {
        if(reader.HasRows)
        {
          reader.Read();
          result = reader.GetInt32(0);
        }
      }
    } finally {
      conn.Close();
    }
    return result;
