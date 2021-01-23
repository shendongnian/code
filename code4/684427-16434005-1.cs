    public static string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\\Folder; Extended Properties=dBASE IV;";
    OleDbConnection c= new OleDbConnection(connStr);
    c.open();
    OleDbDataAdapter da=new OleDbDataAdapter("Select * from Table11",c);
    DataSet ds=new Dataset();
    da.Fill(ds);
    c.Close();
