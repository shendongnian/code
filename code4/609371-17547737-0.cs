    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Threading;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.Win32;
    
    namespace DatabaseUtility
    {
        public class BackupRestore
        {
            static Server srv;
            static ServerConnection conn;
    
            public static void BackupDatabase(string serverName, string databaseName, string filePath)
            {
                conn = new ServerConnection();
                conn.ServerInstance = serverName;
                srv = new Server(conn);
    
                try
                {
                    Backup bkp = new Backup();
    
                    bkp.Action = BackupActionType.Database;
                    bkp.Database = databaseName;
    
                    bkp.Devices.AddDevice(filePath, DeviceType.File);
                    bkp.Incremental = false;
    
                    bkp.SqlBackup(srv);
    
                    conn.Disconnect();
                    conn = null;
                    srv = null;
                }
    
                catch (SmoException ex)
                {
                    throw new SmoException(ex.Message, ex.InnerException);
                }
                catch (IOException ex)
                {
                    throw new IOException(ex.Message, ex.InnerException);
                }
            }
    
            public static void RestoreDatabase(string serverName, string databaseName, string filePath)
            {
    
                conn = new ServerConnection();
                conn.ServerInstance = serverName;
                srv = new Server(conn);
    
                try
                {
                    Restore res = new Restore();
    
                    res.Devices.AddDevice(filePath, DeviceType.File);
    
                    RelocateFile DataFile = new RelocateFile();
                    string MDF = res.ReadFileList(srv).Rows[0][1].ToString();
                    DataFile.LogicalFileName = res.ReadFileList(srv).Rows[0][0].ToString();
                    DataFile.PhysicalFileName = srv.Databases[databaseName].FileGroups[0].Files[0].FileName;
    
                    RelocateFile LogFile = new RelocateFile();
                    string LDF = res.ReadFileList(srv).Rows[1][1].ToString();
                    LogFile.LogicalFileName = res.ReadFileList(srv).Rows[1][0].ToString();
                    LogFile.PhysicalFileName = srv.Databases[databaseName].LogFiles[0].FileName;
    
                    res.RelocateFiles.Add(DataFile);
                    res.RelocateFiles.Add(LogFile);
    
                    res.Database = databaseName;
                    res.NoRecovery = false;
                    res.ReplaceDatabase = true;
                    res.SqlRestore(srv);
                    conn.Disconnect();
                }
                catch (SmoException ex)
                {
                    throw new SmoException(ex.Message, ex.InnerException);
                }
                catch (IOException ex)
                {
                    throw new IOException(ex.Message, ex.InnerException);
                }
            }
    
            public static Server Getdatabases(string serverName)
            {
                conn = new ServerConnection();
                conn.ServerInstance = serverName;
                
                srv = new Server(conn);
                conn.Disconnect();
                return srv;
    
            }
        }
    }
