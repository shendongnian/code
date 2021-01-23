    string conn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
    "Data Source=" + Your D S+ ";" +
    "Extended Properties=Excel 8.0;";
    OleDbConnection sSourceConnection = new OleDbConnection(conn);
    using (sSourceConnection)
    {
       DataTable dtExcelData = new DataTable();
       string[] SheetNames = GetExcelSheetNames(strFileName);
       string[] preColumnHeader = new string[]{ "CarrierId", "StateId", "TerrCd", "ProgramId", "ClassId",
       "PremTypeID","Limit50_100", "Limit100_100", "Limit100_200", "Limit300_300", "Limit300_600", 
       "Limit500_500","Limit500_1mil", "Limit1mil_1mil", "Limit1mil_2mil", "OtherParameter" };
       sSourceConnection.Open();
       string strQuery = string.Empty;
       strQuery = "SELECT * FROM [" + SheetNames[0] + "]";
      
       OleDbDataAdapter oleDA = new OleDbDataAdapter(strQuery, sSourceConnection);
       oleDA.Fill(dtExcelData);
       sSourceConnection.Close();
       string[] colName = new string[dtExcelData.Columns.Count];
       int i = 0;
       foreach (DataColumn dc in dtExcelData.Columns)
       {
           colName[i] = dc.ColumnName;
           i++;
       }
       using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connStr))
       {
           bulkCopy.DestinationTableName = "tbl_test";
           bulkCopy.WriteToServer(dtExcelData);
       }
    }
