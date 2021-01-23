    public void ReadDirectoryContent() 
    {
        var subdirectories = Directory.GetDirectories(RootDirectory);
        List<string> files = new List<string>();
        
        for(int i = 0; i < subdirectories.Length; i++)
           files.Concat(Directory.GetFiles(subdirectories[i], "*", SearchOption.TopDirectoryOnly));
    }
