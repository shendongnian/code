    string sourceDir = @"E:\Images\3\2\1";
    string destName = "1";
    string destDir = @"E:\Images\33\22\";
    
    if (!Directory.Exists(sourceDir))
    {
        Console.WriteLine("Source Directory does not exist.");
        Console.Read();
        //return; // Handle issue where Source Dir does not exist.
    }
    
    if (!Directory.Exists(destDir))
    {
        Console.WriteLine("Destination Directory does exist. Created.");
        Directory.CreateDirectory(destDir);
    }
    if (Directory.Exists(Path.Combine(destDir + destName)))
    {
        Console.WriteLine("Target Destination already exist.");
        Console.Read();
        return;
    }
                
    Directory.Move(sourceDir, Path.Combine(destDir + destName));
    Console.Read();
