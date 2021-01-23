    public SqlConnection dbCon()
    {
     SqlConnection sqlConn;
    
     try
     {
       sqlConn = new SqlConnection(@"Data Source =VirtualXP-64805;Initial Catalog=CTS_Demo;Integrated Security=SSPI")
    
     }
     catch(SqlException)
     {
      //your exception handling details
      sqlConn = null;
     }
    return sqlConn;
    
    }
