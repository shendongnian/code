    try
    {
     con.Open();
     foreach (DataRow rowS99 in dtS99.Rows)
     {
      da.InsertCommand = con.CreateCommand();
      da.InsertCommand.Parameters.AddWithValue("@wertListName", rowS99["WertListName"]);
      da.InsertCommand.Parameters.AddWithValue("@key", rowS99["Key"]);
      da.InsertCommand.Parameters.AddWithValue("@bezeichner", rowS99["Bezeichner"]);
      da.InsertCommand.Parameters.AddWithValue("@keyAufbereitet", rowS99["KeyAufbereitet"]);
      da.InsertCommand.CommandText = sql;
      da.InsertCommand.ExecuteNonQuery();
     }
     con.Close();
     check = true;
     OleDb.OleDbConnection.ReleaseObjectPool();
     GC.Collect();  // I know attation
    }
