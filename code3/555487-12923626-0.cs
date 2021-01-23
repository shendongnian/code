    // property
    public SqlConnection myConnection { get; set; }
    
    // method
    public SqlConnection GetSqlConnection()
    {
         if (myConnection == null) 
           myConnection = new SqlConnection("user id=" + us + ";" +
                                           "password=" + pas + ";server=PANDORA;" +
                                           "Trusted_Connection=yes;" +
                                           "database=NHS; " +
                                           "connection timeout=30");
    
         return myConnection;
    }
