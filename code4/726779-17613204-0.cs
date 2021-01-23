    public List<string> Search()
    {
        var files = new List<string>();
        foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady))
        {
            try
            {
                files.AddRange(Directory.GetFiles(d.RootDirectory.FullName, "*.txt", SearchOption.AllDirectories));
            }
            catch(Exception e)
            {
                Logger.Log(e.Message); // Log it and move on
            }
        }
    
        return files;
    }
