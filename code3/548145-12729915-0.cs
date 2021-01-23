    // in your caller method
    ProcessFolder(@"C:/TestFolder/");
    void ProcessFolder(string path)
    {
        foreach (var file in DirectoryInfo.EnumerateFiles(path))
        {
            if(file.Attributes & FileAttributes.Directory == FileAttributes.Directory)
                ProcessFolder(file.FullName); // recursively handle a directory
            else
                Console.Out.Writeline(file.FullName); // handle a file
        }
    }
