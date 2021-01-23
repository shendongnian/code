    string connectionString = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + filename + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
    string testCaseName = "case_1";
    string query = "SELECT * from [Sheet1$] WHERE TestCaseName=\"" + testCaseName + "\"";
    DataTable dt = new DataTable();
    using (OleDbConnection conn = new OleDbConnection(connectionString))
    {
        conn.Open();
        using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, conn))
        {
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dt = ds.Tables[0];
        }
        conn.Close();
    }
