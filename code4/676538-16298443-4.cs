    internal class DriveWatcher
    {
        public delegate void OpticalDiskArrivedEventHandler(Object sender, OpticalDiskArrivedEventArgs e);
        /// <summary>
        ///     Gets or sets the time, in seconds, before the drive watcher checks for new media insertion relative to the last occurance of check.
        /// </summary>
        public int Interval = 1;
        private Timer _driveTimer;
        private Dictionary<string, bool> _drives;
        private bool _haveDisk;
        /// <summary>
        ///     Occurs when a new optical disk is inserted or ejected.
        /// </summary>
        public event OpticalDiskArrivedEventHandler OpticalDiskArrived;
        private void OnOpticalDiskArrived(OpticalDiskArrivedEventArgs e)
        {
            OpticalDiskArrivedEventHandler handler = OpticalDiskArrived;
            if (handler != null) handler(this, e);
        }
        public void Start()
        {
            _drives = new Dictionary<string, bool>();
            foreach (
                DriveInfo drive in
                    DriveInfo.GetDrives().Where(driveInfo => driveInfo.DriveType.Equals(DriveType.CDRom)))
            {
                _drives.Add(drive.Name, drive.IsReady);
            }
            _driveTimer = new Timer {Interval = Interval*1000};
            _driveTimer.Elapsed += DriveTimerOnElapsed;
            _driveTimer.Start();
        }
        public void Stop()
        {
            if (_driveTimer != null)
            {
                _driveTimer.Stop();
                _driveTimer.Dispose();
            }
        }
        private void DriveTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            if (!_haveDisk)
            {
                try
                {
                    _haveDisk = true;
                    foreach (DriveInfo drive in from drive in DriveInfo.GetDrives()
                                                where drive.DriveType.Equals(DriveType.CDRom)
                                                where _drives.ContainsKey(drive.Name)
                                                where !_drives[drive.Name].Equals(drive.IsReady)
                                                select drive)
                    {
                        _drives[drive.Name] = drive.IsReady;
                        OnOpticalDiskArrived(new OpticalDiskArrivedEventArgs {Drive = drive});
                    }
                }
                catch (Exception exception)
                {
                    Debug.Write(exception.Message);
                }
                finally
                {
                    _haveDisk = false;
                }
            }
        }
    }
    internal class OpticalDiskArrivedEventArgs : EventArgs
    {
        public DriveInfo Drive;
    }
