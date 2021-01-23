    // Retrieve the ConnectionString from App.config 
    string connectString =ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectString);
    // Retrieve the DataSource property.    
    string IPAddess = builder.DataSource;
