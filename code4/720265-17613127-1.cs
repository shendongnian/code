    public static ReadData(string filePath, string sheetName, List<string> fieldsToRead, int startPoint, int endPoint)
    {
        DataTable dt = new DataTable();
        try
        {
            string ConnectionString = ProcessFile.getConnectionString(filePath, false, false);
            using (OleDbConnection cn = new OleDbConnection(ConnectionString))
            {
                cn.Open();
                DataTable dbSchema = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dbSchema == null || dbSchema.Rows.Count < 1)
                {
                    throw new Exception("Error: Could not determine the name of the first worksheet.");
                }
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT *");
                sb.Append(" FROM [" + sheetName + fieldsToRead[0].ToUpper() + startPoint + ":" + fieldsToRead[1].ToUpper() + endPoint + "] ");
                OleDbDataAdapter da = new OleDbDataAdapter(sb.ToString(), cn);
                dt = new DataTable(sheetName);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
    		        string i = row[0].ToString();
                    }
                }
                cn.Dispose();
                return fileDatas;
            }
        }
        catch (Exception)
        {
        }
    }
