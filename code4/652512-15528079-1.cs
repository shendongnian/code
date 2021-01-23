    DriveInfo drive = GetDrives();
    
    foreach(DriveInfo d in drive)
    {
        Console.WriteLine("Drive {0}", d.Name);
        Console.WriteLine" File Type: {0}", d.DriveType);
    
        if(d.IsReady == true)
        {
             Console.WriteLine(" Volume Label: {0}", d.VolumeLabel);
        }
    }
