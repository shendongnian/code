    public bool result()
    {    
        Dictionary<string, string> files = new Dictionary<string, string>();
        files.Add("esecpath", "C:\\testconfig.xml");
        // ... etc for each file
    
        // if you want to see if any don't exist, then use ...
        // if(files.Any(f => !File.Exists(f.Value)))
        // else, these are all the created files
        var createdFiles = files.Where(f => !File.Exists(f.Value));
        if(createdFiles.Count() > 0)
        {
            // A file doesn't exist!  Therefore you are creating it!
        }
        var directories = files.Select(f => Checking.CitXml(f.Value, f.Key));
    
        return directories.All(d => Directory.Exists(d));
    }
