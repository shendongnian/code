    public static string DataDirectory
    {
        get
        {
            if (string.IsNullOrEmpty(Directory))
                return null;
            
            // Use Path.Combine just one time 
            string firstFolder = Path.Combine(Directory, "Data/folder1"); 
            if(Directory.Exists(firstFolder)
                return Path.Combine(firstFolder);
            else
                return Path.Combine(Directory, "Data/folder2");
        }
    }
