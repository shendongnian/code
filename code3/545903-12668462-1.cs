    private string LocateEXE(String filename)
    {
        String path = Environment.GetEnvironmentVariable("path");
        String[] folders = path.Split(';');
        foreach (String folder in folders)
        {
            if (File.Exists(Path.Combine(folder, filename)))
            {
                return folder + filename;
            } 
            else if (File.Exists(Path.Combine(folder, filename))) 
            {
                return Path.Combine(folder, filename);
            }
        }
    
        return String.Empty;
    }
