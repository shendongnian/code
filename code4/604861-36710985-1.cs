    string POCpath = @"G:\Althaf\abc.xlsx";
    string POCConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + POCpath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\";";
    OleDbConnection POCcon = new OleDbConnection(POCConnection);
    OleDbCommand POCcommand = new OleDbCommand();
    DataTable dt = new DataTable();
    OleDbDataAdapter POCCommand = new OleDbDataAdapter("select * from [Sheet1$] ", POCcon);
    POCCommand.Fill(dt);
    Console.WriteLine(dt.Rows.Count);
