    DriveInfo[] allDrives = DriveInfo.GetDrives();
    
    foreach (DriveInfo d in allDrives)
    {
       if (d.IsReady == true)
       {
          var paths = Traverse(d.Name);
          File.AppendAllLines(@"File path for the list", paths);
       }
    }
