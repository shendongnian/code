    sqlQuery = "SELECT `ID` from `users` WHERE `CallerName`=?";
    int result = 0;
    OleDbConnection conn = new OleDbConnection(connectionString);
    try {
      conn.Open();
      cmd = new OleDbCommand(sqlQuery, conn);
      //cmd.CommandText = sqlQuery; This command was specified by your initializer
      cmd.Parameters.Add("?", OleDbType.VarChar).Value = labelProblemDate.Text.Trim();
      //cmd.Parameters["@CallerName"].Value = name; Possible bug here
      using (OleDbReader r = cmd.ExecuteReader())
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
