    string exeRuntimeDirectory = 
        System.IO.Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().Location);
    string subDirectory = 
        System.IO.Path.Combine(exeRuntimeDirectory, "Output");
    if (!System.IO.Directory.Exists(subDirectory))
    {
        // Output directory does not exist, so create it.
        System.IO.Directory.CreateDirectory(subDirectory);
    }
