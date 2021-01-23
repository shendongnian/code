    private DataTable ReadExcelFile(string sheetName, string path)
    {
        using (OleDbConnection conn = new OleDbConnection())
        {
            DataTable dt = new DataTable();
            string Import_FileName = path;
            string fileExtension = Path.GetExtension(Import_FileName);
            if (fileExtension == ".xls")
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
            if (fileExtension == ".xlsx")
                conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            using (OleDbCommand comm = new OleDbCommand())
            {
                comm.CommandText = "Select * from [" + sheetName + "$]";
                comm.Connection = conn;
                using (OleDbDataAdapter da = new OleDbDataAdapter())
                {
                    da.SelectCommand = comm;
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
