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
                        return table;
                    }
                  catch (Exception ex)
                  { }
             }
         }
