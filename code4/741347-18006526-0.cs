     static void Main(string[] args)
            {
                string filename = @"c:\temp\myfile.xlsx";
      
         
            System.Data.OleDb.OleDbConnection myConnection = new System.Data.OleDb.OleDbConnection( 
                            "Provider=Microsoft.ACE.OLEDB.12.0; " +
                             "data source='" + filename + "';" +
                                "Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\" ");
             
            
            myConnection.Open();
            DataTable mySheets = myConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            DataSet ds = new DataSet();
            DataTable dt;
            for (int i = 0; i <= mySheets.Rows.Count; i++)
            {
                    dt =   makeDataTableFromSheetName(filename, mySheets.Rows[i]["TABLE_NAME"].ToString());
                    ds.Tables.Add(dt);
            }
        }
    private static DataTable makeDataTableFromSheetName(string filename, string sheetName)
    {
       
        System.Data.OleDb.OleDbConnection myConnection = new System.Data.OleDb.OleDbConnection(
                        "Provider=Microsoft.ACE.OLEDB.12.0; " +
                         "data source='" + filename + "';" +
                            "Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\" ");
        DataTable dtImport = new DataTable();
        System.Data.OleDb.OleDbDataAdapter myImportCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + sheetName + "$]", myConnection);
        myImportCommand.Fill(dtImport);
        return dtImport;
    }
