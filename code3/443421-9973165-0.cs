    var userPath = Environment.GetFolderPath(Environment
                                                 .SpecialFolder.ApplicationData);
    var filename = Path.Combine(userPath, "mysettings");
    
    // Read connection string
    var connectionString = File.ReadAllText(filename);
    
    // Write connection string
    File.WriteAllText(filename, connectionString);
