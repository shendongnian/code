    foreach (String folder in folders)
    {
    
        DirectoryInfo source = new DirectoryInfo(folder);
        String k = Directory.GetDirectoryRoot(path);
        k = k.Replace(@":\", "");
        DriveInfo c = new DriveInfo(k);
        Double cAvailableSpace = c.AvailableFreeSpace / Math.Pow(1024, 2);
    
    
        // Get info of each file into the directory
        foreach (DirectoryInfo fi in source.GetDirectories())
        {
            var creationTime = fi.CreationTime;
    
            if (creationTime < (DateTime.Now - new TimeSpan(days, 0, 0, 0)))
            {
                if (cAvailableSpace < neededSpace)
                {
                        **/* Trying to delete Folder, but should be FI.Fullname */**
                        Directory.Delete(folder,true);
                }
            }
        }
    }
    }
