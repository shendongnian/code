       private void btnCreate_Click(object sender, EventArgs e)
        {
        // If there was a SQL connection created
        
        if (srvSql != null)
        {
        
        // If the user has chosen a path where to save the backup file
        
      
       
        
        // Create a new backup operation
        
        Backup bkpDatabase = new Backup();
    
    // Set the backup type to a database backup
    
    bkpDatabase.Action = BackupActionType.Database;
    // Set the database that we want to perform a backup on
    
    bkpDatabase.Database = cmbDatabase.SelectedItem.ToString();
    
    // Set the backup device to a file
    string myPath = " a path whic you want to save  ";   
    
    
    //string myPath = @"C:/backups/mybackup.sql";   
    
    BackupDeviceItem bkpDevice = new BackupDeviceItem(myPath , DeviceType.File);
    
    // Add the backup device to the backup
    
    bkpDatabase.Devices.Add(bkpDevice);
    
    // Perform the backup
    
    bkpDatabase.SqlBackup(srvSql);
    
   
    }
    else
    {
    
    // There was no connection established; probably the Connect button was not clicked
    
    MessageBox.Show("A connection to a SQL server was not established.", "Not Connected to Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    
    }
     }
