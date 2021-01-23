    bool GetFileInformation(File f, out string name)
    {
        name=null;
        try
        {
           FileInfo info = new FileInfo(f);
           FileSystemInfo sysInfo = new FileSystemInfo(f);
           name=sysInfo.Name;
        }
        catch(Exception ex)
        {
            return false;
        }
        return true;
    }
