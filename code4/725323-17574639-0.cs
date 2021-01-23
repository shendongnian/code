    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Data;
    
    
            /// <summary>
            /// Backups the data base.
            /// </summary>
            /// <param name="fileName">Name of the file.</param>
            /// <returns></returns>
            public bool BackupDataBase(string fileName)
            {
                if (string.IsNullOrEmpty(fileName))
                    return false;
                bool isDatabackedUp = true;
                try
                {
    
                    Backup sqlBackup = new Backup();
    
                    sqlBackup.Action = BackupActionType.Database;
                    sqlBackup.BackupSetDescription = "ArchiveDataBase:" +
                                                     DateTime.Now.ToShortDateString();
    
                    sqlBackup.BackupSetName = "Archive";
    
    
                    BackupDeviceItem deviceItem = new BackupDeviceItem(fileName, DeviceType.File);
                    ServerConnection connection = new ServerConnection(this.BackupConnection);
                    DataConnection dataConnection = new DataConnection();
    
                    Server sqlServer = new Server(dataConnection.ServerName);
                    Database db = sqlServer.Databases[dataConnection.DataBaseName];
    
                    sqlBackup.Database = dataConnection.DataBaseName;
                    sqlBackup.Initialize = true;
                    sqlBackup.Checksum = true;
                    sqlBackup.ContinueAfterError = true;
    
                    sqlBackup.Devices.Add(deviceItem);
                    sqlBackup.Incremental = false;
    
                    sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);
                    sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;
    
                    sqlBackup.FormatMedia = false;
    
                    sqlBackup.SqlBackup(sqlServer);
    
                    return isDatabackedUp;
    
                }
                catch (Exception)
                {
                    return false;
    
                }
    
            }
        private SqlConnection BackupConnection
        {
            get
            {
                string backupConnectionString = string.Empty;
                ConnectionStringSettings settings =
                    ConfigurationManager.ConnectionStrings["LibrarySystemBackUpConnection"];
                backupConnectionString = settings.ConnectionString;
                SqlConnection backupDatabaseConnection = new SqlConnection(backupConnectionString);
                return backupDatabaseConnection;
            }
        }
