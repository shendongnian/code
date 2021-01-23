    string[] drives = Environment.GetLogicalDrives();
    foreach (string drive in drives)
    {
        try
        {
            DriveInfo di = new DriveInfo(drive);
            if (di.VolumeLabel == "STAR-LIGHT")
            {
                // code
            }
        }
        catch
        {
            // ...
        }
    }
