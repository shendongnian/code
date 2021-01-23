            Server myServer = new Server(@".\SQLExpress");
            Database mydb = myServer.Databases["DB1"];
            if(mydb!=null)
               myServer.KillAllProcesses(mydb.Name);//detach
            Restore restoreDB = new Restore();
            restoreDB.Database = mydb.Name;
            restoreDB.Action = RestoreActionType.Database;
            restoreDB.Devices.AddDevice(_path, DeviceType.File);
           
            restoreDB.ReplaceDatabase = true;
            restoreDB.NoRecovery = false;
            restoreDB.SqlRestore(myServer);
