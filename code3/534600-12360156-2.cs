        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo("dirctory path");
        List<System.IO.FileInfo> files = di.GetFiles().ToList();
        di = null;  // at this point I don't think you need to hold on to di
        // the static Directory will return string file names
        // randomize files using the code in the link 
        Random random = new Random();
        foreach (System.IO.FileInfo fi in files)
        {
            Thread.Sleep(random.Next(1000, 3600000));
            // should probaly test the fi is still valid
            fi.CopyTo("desitination");
        }
