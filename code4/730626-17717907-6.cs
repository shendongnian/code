    using (var con = new SQLiteConnection(preparedConnectionString))
          {
              using (var cmd = new SQLiteCommand("PRAGMA table_info(" + tableName + ");"))
              {
                  var table = new DataTable();
                  cmd.Connection = con;
                  cmd.Connection.Open();
                  SQLiteDataAdapter adp = null;
                  try
                  {
                      adp = new SQLiteDataAdapter(cmd);
                      adp.Fill(table);
                      con.Close();
                      var res = new List<string>();
                      for(int i = 0;i<table.Rows.Count;i++)
                          res.Add(table.Rows[i]["name"].ToString());
                      return res;
                  }
                  catch (Exception ex){ }
              }
          }
          return new List<string>();
