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
