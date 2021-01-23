    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename +
        "; Extended Properties=\"Excel 12.0 XML;HDR=YES\"";
    DataSet dsValues = new DataSet();
    using (OleDbConnection conn = new OleDbConnection(connectionString))
    {
        conn.Open();
        using (OleDbCommand cmd = conn.CreateCommand())
        {
            using (OleDbDataAdapter adapter = new OleDbDataAdapter())
            {
                foreach (Excel.Worksheet wsheet in workbook.Worksheets)
                {
                    cmd.CommandText = "SELECT * FROM [" + wsheet.Name + "$]";
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dsValues.Tables.Add(wsheet.Name));
                }
            }
        }
    }
