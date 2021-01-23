    public void Init()
    {
        String platypusDir = @"C:\platypus";
        CreateDirectoryIfDoesNotExist(platypusDir);
    }
    
    private void CreateDirectoryIfDoesNotExist(string dirName)
    {
        System.IO.Directory.CreateDirectory(dirName);
    }
