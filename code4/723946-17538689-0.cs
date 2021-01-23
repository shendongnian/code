    string myAppPath = System.Reflection.Assembly.GetEntryAssembly().Location;
    if (File.Exists(Path.Combine(myAppPath, pathToExe)))
    {
        workDir = Path.GetDirectoryName(Path.Combine(myAppPath, pathToExe));
    }
    else 
    {
        // Use the referenced article to iterate thru System PATH to find the right path
    }
