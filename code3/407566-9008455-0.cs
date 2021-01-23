    public bool result()
    {    
        Dictionary<string, string> files = new Dictionary<string, string>();
        files.Add("esecpath", "C:\\testconfig.xml");
        // ... etc for each file
    
        if(files.Any(f => !File.Exists(f.Value)))
        {
            // A file doesn't exist!  Therefore you are creating it!
        }
        var directories = files.Select(f => Checking.CitXml(f.Value, f.Key));
    
        return directories.All(d => Directory.Exists(d));
    }
