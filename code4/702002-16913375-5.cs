    public void BackupDatabase(String databaseName, String userName, 
            String password, String serverName, String destinationPath)
     {
   
     Backup sqlBackup = new Backup();
    
    sqlBackup.Action = BackupActionType.Database;
    sqlBackup.BackupSetDescription = "ArchiveDataBase:" + 
                                     DateTime.Now.ToShortDateString();
    sqlBackup.BackupSetName = "Archive";
    sqlBackup.Database = databaseName;
    BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath, DeviceType.File);
    ServerConnection connection = new ServerConnection(serverName, userName, password);
    Server sqlServer = new Server(connection);
    
    Database db = sqlServer.Databases[databaseName];
    
    sqlBackup.Initialize = true;
    sqlBackup.Checksum = true;
    sqlBackup.ContinueAfterError = true;
    
    sqlBackup.Devices.Add(deviceItem);
    sqlBackup.Incremental = false;
    sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);
    sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;
    sqlBackup.FormatMedia = false;
    sqlBackup.SqlBackup(sqlServer);
  
    }
    public void RestoreDatabase(String databaseName, String filePath, 
           String serverName, String userName, String password, 
           String dataFilePath, String logFilePath)
    {
        Restore sqlRestore = new Restore();
    
    BackupDeviceItem deviceItem = new BackupDeviceItem(filePath, DeviceType.File);
    sqlRestore.Devices.Add(deviceItem);
    sqlRestore.Database = databaseName;
    ServerConnection connection = new ServerConnection(serverName, userName, password);
    Server sqlServer = new Server(connection);
    Database db = sqlServer.Databases[databaseName];
    sqlRestore.Action = RestoreActionType.Database;
    String dataFileLocation = dataFilePath + databaseName + ".mdf";
    String logFileLocation = logFilePath + databaseName + "_Log.ldf";
    db = sqlServer.Databases[databaseName];
    RelocateFile rf = new RelocateFile(databaseName, dataFileLocation);
    
    sqlRestore.RelocateFiles.Add(new RelocateFile(databaseName, dataFileLocation));
    sqlRestore.RelocateFiles.Add(new RelocateFile(databaseName+"_log", logFileLocation));
    sqlRestore.ReplaceDatabase = true;
    sqlRestore.Complete += new ServerMessageEventHandler(sqlRestore_Complete);
    sqlRestore.PercentCompleteNotification = 10;
    sqlRestore.PercentComplete += 
       new PercentCompleteEventHandler(sqlRestore_PercentComplete);
            
    sqlRestore.SqlRestore(sqlServer);
    db = sqlServer.Databases[databaseName];
    db.SetOnline();
    sqlServer.Refresh();
    }
