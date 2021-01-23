     using System;
        using System.Configuration;
        using System.IO;
        using System.Data.SqlClient;
        using Microsoft.SqlServer.Management.Smo;
        using Microsoft.SqlServer.Management.Common;
    
    public bool BackupDataBase()
            {
                bool isDatabackedUp = true;
                try
                {
                    Backup sqlBackup = new Backup();
    
                    if (null != sqlBackup)
                    {
                        //Set the Database backup type
                        sqlBackup.Action = BackupActionType.Database;
    
                        //Set database backup description to be kept in the back up log table
                        sqlBackup.BackupSetDescription = Constants.DatabaseBackupDescription +
                                                         DateTime.Now.ToShortDateString();
    
                        sqlBackup.BackupSetName = Constants.DatabaseBackupSetName;
    
                        //Set the backup file path and backup type
                        BackupDeviceItem deviceItem = new BackupDeviceItem(DatabaseBackupFilePath, DeviceType.File);
                        ServerConnection connection = new ServerConnection(this.BackupConnection);
    
                        //Set the database name to backup
                        sqlBackup.Database = LocalDatabaseName;
                        sqlBackup.Initialize = true;
                        sqlBackup.Checksum = true;
                        sqlBackup.ContinueAfterError = true;
    
                        //Set the file details to save the backup
                        sqlBackup.Devices.Add(deviceItem);
                        sqlBackup.Incremental = false;
    
                        sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;
                        sqlBackup.FormatMedia = false;
    
                        //Intiate the database backup
                        Server sqlServer = new Server(connection);
                        sqlBackup.SqlBackup(sqlServer);
                    }
                    
                    return isDatabackedUp;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
