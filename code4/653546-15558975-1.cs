    static string rsnREAD(string dbTbl)
        {
            string result = string.Empty;
            OleDbConnection machStopDB = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @"C:\Users\sgarner\Google Drive\Visual Studio 2012\Write_to_db\Write_to_db\Machine_Stop.accdb");
            //string sDate;
            //sDate = DateTime.Now.ToString("MM/dd/yyy HH:mm:ss");
            string str = "SELECT LAST(REASON) AS lastREASON FROM "+dbTbl+"";
            OleDbCommand rdCmd = new OleDbCommand(str, machStopDB);
            try
            {
                machStopDB.Open();
                OleDbDataReader reader = rdCmd.ExecuteReader();
                if(reader.Read())
                {
                    result = reader[0].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                machStopDB.Close();
            }
            return result;
        }
