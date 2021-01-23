    class DriveSystemWatcher
    {
    	/// <summary>
    	/// Gets or sets the time, in seconds, before the drive watcher checks for new media insertion relative to the last occurance of check.
    	/// </summary>
    	public int Interval = 2;
    
    	/// <summary>
    	/// Occurs when a new optical disk is inserted or ejected.
    	/// </summary>
    	public event OpticalDiskArrivedEventHandler OpticalDiskArrived;
    
    	public delegate void OpticalDiskArrivedEventHandler(Object sender, OpticalDiskArrivedEventArgs e);
    
    	private Dictionary<string, bool> _drives;
    
    	private void OnOpticalDiskArrived(OpticalDiskArrivedEventArgs e)
    	{
    		var handler = OpticalDiskArrived;
    		if (handler != null) handler(this, e);
    	}
    
    	public void Start()
    	{
    		_drives = new Dictionary<string, bool>();
    		foreach (var drive in DriveInfo.GetDrives().Where(driveInfo => driveInfo.DriveType.Equals(DriveType.CDRom)))
    		{
    			_drives.Add(drive.Name, drive.IsReady);
    		}
    		var driveTimer = new Timer {Interval = Interval * 1000};
    		driveTimer.Elapsed += DriveTimerOnElapsed;
    		driveTimer.Start();
    	}
    
    	private void DriveTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
    	{
    		foreach (var drive in DriveInfo.GetDrives())
    		{
    			if (drive.DriveType.Equals(DriveType.CDRom))
    			{
    				if (_drives.ContainsKey(drive.Name))
    				{
    					if (!_drives[drive.Name].Equals(drive.IsReady))
    					{
    						_drives[drive.Name] = drive.IsReady;
    						OnOpticalDiskArrived(new OpticalDiskArrivedEventArgs { Drive = drive });
    					}
    				}
    			}
    		}
    	}
    }
    
    class OpticalDiskArrivedEventArgs : EventArgs
    {
    	public DriveInfo Drive;
    }
