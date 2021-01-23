     OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties='Excel 12.0 xml;HDR=YES;'");
                            connection.Open();
                            DataTable Sheets = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        
               foreach (DataRow dr in Sheets.Rows)
                        {
                           string sht = dr[2].ToString().Replace("'", "");
                            OleDbDataAdapter dataAdapter = new OleDbDataAdapter("select * from [" + sht + "]", connection);
        }
