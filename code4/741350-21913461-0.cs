    DataTable dtImport = new DataTable();
    using ( System.Data.OleDb.OleDbConnection myConnection = new System.Data.OleDb.OleDbConnection(
                "Provider=Microsoft.ACE.OLEDB.12.0; " +
                 "data source='" + filename + "';" +
                    "Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\" ")){
    using ( System.Data.OleDb.OleDbDataAdapter myImportCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + sheetName + "$]", myConnection))
    myImportCommand.Fill(dtImport);
    } return dtImport;
