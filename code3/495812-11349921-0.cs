    string fileName = "your path to the excel.xls"; // From the dialog box.
    OleDbConnectionStringBuilder connStringBuilder =
        new OleDbConnectionStringBuilder();
 
    connStringBuilder.DataSource = fileName;  // Set path to excel file
    connStringBuilder.Provider = "Microsoft.Jet.OLEDB.4.0";
    connStringBuilder.Add("Extended Properties", "Excel 8.0;HDR=YES;IMEX1");        
    ...
    // Get the connection string from the builder.
    connection.ConnectionString = connStringBuilder.ConnectionString; 
