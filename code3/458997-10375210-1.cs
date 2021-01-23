    using System.Data.Odbc;
    
    using(OdbcConnection myConnection = new OdbcConnection())
    {
        myConnection.ConnectionString = myConnectionString;
        myConnection.Open();
    
        //execute queries, etc
    
    }
