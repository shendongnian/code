    string connectionString = String.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=no;IMEX=1;""", openFileDialog1.FileName);
    int numberOfSheets = 0;
    using (OleDbConnection conn = new OleDbConnection(connectionString))
    {
        conn.Open();
        DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        if (dt != null)
        {
            numberOfSheets = dt.AsEnumerable().Cast<DataRow>().Where(row => row["TABLE_NAME"].ToString().EndsWith("$")).Count();
        }
    }
