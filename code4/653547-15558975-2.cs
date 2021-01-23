    static string rsnREAD(string dbTbl)
        {
          string result = string.Empty;
          using(var machStopDB = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @"C:\Users\sgarner\Google Drive\Visual Studio 2012\Write_to_db\Write_to_db\Machine_Stop.accdb");
          {
            string str = "SELECT LAST(REASON) AS lastREASON FROM "+dbTbl+"";
            OleDbCommand rdCmd = new OleDbCommand(str, machStopDB);
            try
            {
              machStopDB.Open();
              using(var reader = rdCmd.ExecuteReader())
              {
                if(reader.Read())
                {
                    result = reader[0].ToString();
                }
              }
            }
            catch (Exception ex) // Sample only. Catch only ones you need.
            {
                MessageBox.Show(ex.Message);
            }
          }
          return result;
        }
