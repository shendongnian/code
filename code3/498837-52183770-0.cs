    private void BackupButtonClick(object sender, RoutedEventArgs e)
    {
        // FILE NAME WITH DATE DISTICNTION
        string fileName = string.Format("SchoolBackup_{0}.bak", DateTime.Now.ToString("yyyy_MM_dd_h_mm_tt"));
        try
        {
            // YOUR SEREVER OR MACHINE NAME
            Server dbServer = new Server (new ServerConnection("DESKTOP"));
            Microsoft.SqlServer.Management.Smo.Backup dbBackup = new Microsoft.SqlServer.Management.Smo.Backup()
            {
                Action = BackupActionType.Database, 
                Database = "School"
            };
    
            dbBackup.Devices.AddDevice(@backupDirectory() +"\\"+ fileName, DeviceType.File);
            dbBackup.Initialize = true;
            dbBackup.SqlBackupAsync(dbServer);
    
    
            MessageBox.Show("Backup", "Backup Completed!");
        }
        catch(Exception err)
        {
            System.Windows.MessageBox.Show(err.ToString());
        }
    }
    
    
    // THE DIRECTOTRY YOU WANT TO SAVE IN
    public string backupDirectory()
    {
        using (var dialog = new FolderBrowserDialog())
        {
            var result = dialog.ShowDialog();
            return dialog.SelectedPath;
        }
    }
