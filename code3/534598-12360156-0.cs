        List<System.IO.FileInfo> files = new List<System.IO.FileInfo>();
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo("dirctory path");
        files = di.GetFiles().ToList();
        // randomize files using the code in the link 
        Random random = new Random();
        foreach (System.IO.FileInfo fi in files)
        {
            Thread.Sleep(random.Next(1000, 3600000));
            // should probaly test the fi is still valid
            fi.CopyTo("desitination");
        }
