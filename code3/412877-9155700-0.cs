    DataSet ds_Data = new DataSet();
    OleDbConnection oleCon = new OleDbConnection();
    
    string strExcelFile = @"C:\Test.xlsx";
    oleCon.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strExcelFile + ";Extended Properties=\"Excel 12.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text\"";;
     
     string SpreadSheetName = "";
     
    OleDbDataAdapter Adapter = new OleDbDataAdapter();
    OleDbConnection conn = new OleDbConnection(sConnectionString);
    
    string strQuery;
    conn.Open();
    
    int workSheetNumber = 0;
    
    DataTable ExcelSheets = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
    
    SpreadSheetName = ExcelSheets.Rows[workSheetNumber]["TABLE_NAME"].ToString();
    
    strQuery = "select * from [" + SpreadSheetName + "] ";
    OleDbCommand cmd = new OleDbCommand(strQuery, conn);
    Adapter.SelectCommand = cmd;
    DataSet dsExcel = new DataSet();
    Adapter.Fill(dsExcel);
    conn.Close();
