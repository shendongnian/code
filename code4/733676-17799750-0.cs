    ConnectionInfo connInfo = new ConnectionInfo();
    connInfo.ServerName = "Driver={Adaptive Server Enterprise};Server=x.x.x.x;Port=x;";
    connInfo.DatabaseName = "dbname";
    connInfo.UserID = "username";
    connInfo.Password = "password";
    
    TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
    tableLogOnInfo.ConnectionInfo = connInfo;
    
    foreach(Table table in reportDoc.Database.Tables)
    {
      table.ApplyLogOnInfo(tableLogOnInfo);
      table.LogOnInfo.ConnectionInfo.ServerName = connInfo.ServerName;
      table.LogOnInfo.ConnectionInfo.DatabaseName = connInfo.DatabaseName;
      table.LogOnInfo.ConnectionInfo.UserID = connInfo.UserID;
      table.LogOnInfo.ConnectionInfo.Password = connInfo.Password;
    
      // Apply the schema name to the table's location
      table.Location = "dbo." + table.Location;
    }
