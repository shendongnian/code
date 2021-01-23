    public OracleConnection GetConnection()
    {
            
    //Romove using(...) clouse 
    using (OracleConnection conn = new OracleConnection(_connSettings.GetConnectionString()))
    {return con;}
