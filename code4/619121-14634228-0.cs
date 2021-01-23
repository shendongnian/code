    DriveInfo[] allDrives = DriveInfo.GetDrives();
    foreach (DriveInfo d in allDrives)
    {
        if (d.IsReady && (d.DriveType == DriveType.Fixed || d.DriveType == DriveType.Removable))
        {
            cboSrcDrive.Items.Add(d.Name);
            cboTgtDrive.Items.Add(d.Name);
        }
    }
