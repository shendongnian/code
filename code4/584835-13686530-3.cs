    List<String> databases = new List<String>();
    
    SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();
     connection.DataSource = SelectedServer;
     // enter credentials if you want
     //connection.UserID = //get username;
    // connection.Password = //get password;
     connection.IntegratedSecurity = true;
     
     String strConn = connection.ToString();
     //create connection
      SqlConnection sqlConn = new SqlConnection(strConn);
                            
    //open connection
    sqlConn.Open();
    
     //get databases
    DataTable tblDatabases = sqlConn.GetSchema("Databases");
    
    //close connection
    sqlConn.Close();
    
    //add to list
    foreach (DataRow row in tblDatabases.Rows) {
          String strDatabaseName = row["database_name"].ToString();
    
           databases.Add(strDatabaseName);
    
    
    }     
                 
