    int scanLVL = 4;//or however deep you need to go...
    public  void GetImageFromDir(string sourceDir, int startLVL)
    {
        if (startLVL <= scanLVL)
        {
            // Here you can process files found in the directory.
            string[] fileEntries = Directory.GetFiles(sourceDir);
            Label_showdata.Text +="<br />Dir:" +  Path.GetFileName(sourceDir) ;
            foreach (string fileName in fileEntries)
            {
                // do something with fileName
                String tree = "";
                for (int i = 0; i < startLVL; i++)
                    tree += "&nbsp;&nbsp;&nbsp;";
                Label_showdata.Text += "<br />" + tree + Path.GetFileName(fileName);               
            }
            // Going in subdirectories of this directory.
            string[] subdirEntries = Directory.GetDirectories(sourceDir);
            foreach (string subdir in subdirEntries)
                
                if ((File.GetAttributes(subdir) &  FileAttributes.ReparsePoint) !=    FileAttributes.ReparsePoint)
                    GetImageFromDir(subdir, startLVL + 1);
        }
    }
