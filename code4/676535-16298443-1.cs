    var driveSystemWatcher = new DriveSystemWatcher();
    driveSystemWatcher.OpticalDiskArrived += DriveSystemWatcherOnOpticalDiskArrived;
    driveSystemWatcher.Start();
    
    private void DriveSystemWatcherOnOpticalDiskArrived(object sender, OpticalDiskArrivedEventArgs e)
    {
    	MessageBox.Show(e.Drive.Name);
    }
