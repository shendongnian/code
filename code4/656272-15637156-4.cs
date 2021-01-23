    string sourceDir = @"E:\Images\3\2\1";
    string destName = Path.GetDirectoryName(sourceDir);
    string destDir = @"E:\Images\33\22\";
    
    if (!Directory.Exists(sourceDir))
    {
        Console.WriteLine("Source Directory does not exist.");
        Console.Read();
        //return; // Handle issue where Source Dir does not exist.
    }
    
    if (!Directory.Exists(destDir))
    {
        Console.WriteLine("Destination Directory did not exist. Created.");
        Directory.CreateDirectory(destDir);
    }
                
    Directory.Move(sourceDir, Path.Combine(destDir + destName));
    Console.Read();
