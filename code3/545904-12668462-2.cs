    private string LocateEXE(String fileName)
    {
        string path = Environment.GetEnvironmentVariable("path");
        string[] folders = path.Split(';');
        foreach (var folder in folders)
        {
            if (File.Exists(Path.Combine(folder, fileName))) 
            {
                return Path.Combine(folder, fileName);
            }
        }
    
        return String.Empty;
    }
