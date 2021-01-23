    using(OleDbConnection connection = new OleDbConnection(connectionString))
    {
        string sql = "SELECT tblProInfo.proInfoSerialNum FROM tblProInfo ";         
        OleDbCommand command = new OleDbCommand(sql, connection);         
        try 
        {
         ......
        }
        catch(....)
    }
