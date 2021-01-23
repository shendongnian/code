      //set database to single user and kick everyone off
      using (var sqlconnection = new SqlConnection(new DatabaseConfiguration().MakeConnectionString(databaseConfiguration)))
      {
	  	sqlconnection.Open();
        using (var sqlcommand = new SqlCommand("ALTER DATABASE " + databaseConfiguration.DatabaseName + " SET Single_User WITH Rollback IMMEDIATE",sqlconnection))
        {
        	sqlcommand.ExecuteNonQuery();                        
        }
		//setup server connection and restore
		var server = new Server(sqlconnection);
		var restore = new Restore();
		restore.Database = databaseConfiguration.DatabaseName;
		restore.Action = RestoreActionType.Database;
		restore.Devices.AddDevice(databaseFile, DeviceType.File);
		restore.ReplaceDatabase = true;
		restore.Complete += Restore_Complete;
		restore.SqlRestore(server);
		sqlconnection.Close();
      }
