    private string GetNumberOfRows(string filename, string sheetName)
    {
        string connectionString;
        string count = "";
            
        if (filename.EndsWith(".xlsx"))
        {
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=NO\"";
        }
        else if (filename.EndsWith(".xls"))
        {
            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + ";Mode=ReadWrite;Extended Properties=\"Excel 8.0;HDR=NO;\"";
        }
        string SQL = "SELECT COUNT (*) FROM [" + sheetName + "$]";
        using (OleDbConnection conn = new OleDbConnection(connectionString))
        {
            conn.Open();
            using (OleDbCommand cmd = new OleDbCommand(SQL, conn))
            {
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    count = reader[0].ToString();
                }
            }
            conn.Close();
        }
        return count;
    }
