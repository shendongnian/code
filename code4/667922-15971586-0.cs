        string[] drives = System.Environment.GetLogicalDrives();
        foreach (string dr in drives)
        {
            System.IO.DriveInfo di = new System.IO.DriveInfo(dr);
           
            if (!di.IsReady)
            {               
                continue;
            }
            System.IO.DirectoryInfo root = di.RootDirectory;
            var directories = root.GetDirectories("*.*", System.IO.SearchOption.AllDirectories);
            foreach(var dirInfo in directories ) {
                var diAccess = dirInfo.GetAccessControl(..) ;
            }
        }
