    System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
    System.Configuration.ConnectionStringSettings connString;
    if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
    {
        connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
        if (connString != null)
        {
            // Create the connection, open, use and destroy releasing the resources used
            using(SqlConnection myConnection = new SqlConnection(connString))
            {
                 myConnection.Open();
                 .... other database code here
            } 
       }
    }
