    public static DataSet ToDataSet(string exceladdress, int startRecord = 0, int maxRecord = -1, string condition = "")
    {
        DataSet result = new DataSet();
        using (OleDbConnection connection = new OleDbConnection((exceladdress.TrimEnd().ToLower().EndsWith("x")) ? "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + exceladdress + "';" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'"
            : "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + exceladdress + "';Extended Properties=Excel 8.0;"))
            try
            {
                connection.Open();
                DataTable schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                foreach (DataRow drSheet in schema.Rows)
                    if (drSheet["TABLE_NAME"].ToString().Contains("$"))
                    {
                        string s = drSheet["TABLE_NAME"].ToString();
                        if (s.StartsWith("'")) s = s.Substring(1, s.Length - 2);
                        System.Data.OleDb.OleDbDataAdapter command =
                            new System.Data.OleDb.OleDbDataAdapter(string.Join("", "SELECT * FROM [", s, "] ", condition), connection);
                        DataTable dt = new DataTable();
                        if (maxRecord > -1 && startRecord > -1) command.Fill(startRecord, maxRecord, dt);
                        else command.Fill(dt);
                        result.Tables.Add(dt);
                    }
                return result;
            }
            catch (Exception ex) { return null; }
            finally { connection.Close(); }
    }
