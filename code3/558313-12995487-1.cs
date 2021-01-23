    string ServerName = "server";
    string DatabaseName = database;
    string UserId = userId;
    string Password = password;
    ServerConnection serverConnection;
    private Server _server;
    public Server Server
    {
        get
        {
            if (_server == null)
            {
                Connect();
            }
            return _server;
        }
    }
    string connectionString 
    {
        get
        {
            return string.Format("Data Source={0};Initial Catalog={1};UID={2};Password={3}", ServerName, DatabaseName, UserId, Password);
        }
    }
    public void Connect()
    {
        _serverConnection = new ServerConnection();
        _serverConnection.LoginSecure = false;
        _serverConnection.Login = UserId;
        _serverConnection.Password = Password;
        _server = new Server(_serverConnection);
    }
    public void BackupDatabase()
    {
        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            ServerConnection svCon = new ServerConnection(cn);
            Server svr = new Server(svCon);
            cn.Open();
            cn.ChangeDatabase("master");
            string testFolder = @"C:\temp";
            string databaseName = _databaseName;
            Backup backup = new Backup();
            backup.Action = BackupActionType.Database;
            backup.Database = databaseName;
            backup.Incremental = false;
            backup.Initialize = true;
            backup.LogTruncation = BackupTruncateLogType.Truncate;
            string fileName = string.Format("{0}\\{1}.bak", testFolder, databaseName);
            BackupDeviceItem backupItemDevice = new BackupDeviceItem(fileName, DeviceType.File);
            backup.Devices.Add(backupItemDevice);
            backup.PercentCompleteNotification = 10;
            //backup.PercentComplete += backup_PercentComplete;
            //backup.Complete += backup_Complete;
            backup.SqlBackup(svr);
            if (!VerifyBackup(svr))
            {
                //throw new Exception("Backup could not be verified.");
            }
            svr = null;
            cn.Close();
        }
    }
    public bool VerifyBackup(Server svr)
    {
        string testFolder = @"C:\temp";
        string databaseName = _databaseName;
        Restore restore = new Restore();
        restore.Action = RestoreActionType.Database;
        string fileName = string.Format("{0}\\{1}.bak", testFolder, databaseName);
        BackupDeviceItem backupItemDevice = new BackupDeviceItem(fileName, DeviceType.File);
        restore.Devices.AddDevice(fileName, DeviceType.File);
        restore.Database = databaseName;
        restore.PercentCompleteNotification = 10;
        //restore.PercentComplete += new PercentCompleteEventHandler(ProgressEventHandler);
        bool verified = restore.SqlVerify(svr);
        return verified;
    }
    public void RestoreDatabase()
    {
        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            ServerConnection svCon = new ServerConnection(cn);
            Server svr = new Server(svCon);
            cn.Open();
            cn.ChangeDatabase("master");
            string testFolder = @"C:\temp";
            string databaseName = _databaseName;
            Restore restore = new Restore();
            restore.Action = RestoreActionType.Database;
            string fileName = string.Format("{0}\\{1}.bak", testFolder, databaseName);
            BackupDeviceItem backupItemDevice = new BackupDeviceItem(fileName, DeviceType.File);
            restore.Devices.AddDevice(fileName, DeviceType.File);
            restore.Database = databaseName;
            restore.ReplaceDatabase = true;
            restore.PercentCompleteNotification = 10;
            //restore.PercentComplete += new PercentCompleteEventHandler(ProgressEventHandler);
            svr.KillAllProcesses(databaseName);
            restore.SqlRestore(svr);
            svr = null;
            cn.Close();
        }
    }
