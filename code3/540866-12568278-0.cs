    public static System.Data.DataTable GetDataTable(string strFileName)
    {
            System.Data.OleDb.OleDbConnection dbConnect = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + ";Extended Properties = \"Text;HDR=YES;FMT=TabDelimited\"");
            dbConnect.Open();
            string strQuery = "SELECT * FROM [" + System.IO.Path.GetFileName(strFileName) + "]";
            System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strQuery, dbConnect);
            System.Data.DataSet dSet = new System.Data.DataSet("CSV File");
            adapter.Fill(dSet);
            dbConnect.Close();
            return dSet.dbTables[0];
     }
