    public void ProcessFolder(DirectoryInfo dirInfo)
    {
        //Check for sub Directories
        foreach (DirectoryInfo di in dirInfo.GetDirectories())
        {
            //Call itself to process any sub directories
            ProcessFolder(di);
        }
        //Process Files in Directory
        foreach (FileInfo fi in dirInfo.GetFiles())
        {
            ProcessFile(fi)
        }
    } 
