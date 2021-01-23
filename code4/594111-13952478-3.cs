            Server myServer = new Server(@".\SQLExpress");
            Database mydb = myServer.Databases["DB1"];
            Backup bkp = new Backup();
            bkp.Action = BackupActionType.Database;
            bkp.Database = mydb.Name;
         
            bkp.Devices.AddDevice(_path, DeviceType.File);
            bkp.BackupSetName = "DB1 backup";//optional
            bkp.BackupSetDescription = "mybackup dated " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");//optional
           
            bkp.Initialize = true;
            bkp.Incremental = false;
            bkp.SqlBackup(myServer);
