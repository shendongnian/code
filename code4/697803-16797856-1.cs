    static void BackupDataBase(string databaseName, string destinationPath)
    {
        try
        {
            Server myServer = GetServer();
            Backup backup = new Backup();
            backup.Action = BackupActionType.Database;
            backup.Database = databaseName;
            destinationPath = System.IO.Path.Combine(destinationPath, databaseName + ".bak");
            backup.Devices.Add(new BackupDeviceItem(destinationPath, DeviceType.File));
            backup.Initialize = true;
            backup.Checksum = true;
            backup.ContinueAfterError = true;
            backup.Incremental = false;
            backup.LogTruncation = BackupTruncateLogType.Truncate;
            backup.SqlBackup(myServer);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
    
    private static Server GetServer()
    {
        ServerConnection conn = new ServerConnection("server", "username", "pw");
        Server myServer = new Server(conn);
        return myServer;
    }
