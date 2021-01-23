    public DB(string conStr):base()
    {
    con = new OracleConnection(conStr);
    con.Open();
    }
     
     
    public void Close()
    {
    con.Close();
    //con.Dispose();
    
    } 
