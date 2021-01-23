    //Get the connection string from app.config and assign it to sqlconnection string builder
    SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(((EntityConnection)context.Connection).StoreConnection.ConnectionString);
    sb.IntegratedSecurity = false;
    sb.UserID ="User1";
    sb.Password = "Password1";
    
    //set the object context connection string back from string builder. This will assign modified connection string.
    ((EntityConnection)context.Connection).StoreConnection.ConnectionString = sb.ConnectionString;
