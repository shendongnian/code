    [WebMethod] 
    public DataSet GetUser(string UserName) 
    { 
        DataSet ds = new DataSet(); 
        string database = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/dvd_forum.accdb;Persist Security Info=True"; 
        string queryStr = "select * from Users WHERE UserName=" + UserName; 
        OleDbConnection myConn = new OleDbConnection(database); 
        OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(queryStr, myConn); 
        myConn.Open(); 
        myDataAdapter.Fill(ds, "Users"); 
        myConn.Close(); 
        return ds; 
    } 
