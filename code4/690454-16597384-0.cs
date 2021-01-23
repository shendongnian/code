    static void Main()
    {
        // Directory of files.
        const string dir = @"C:\Test";
    
        // File names.
        var files = new DirectoryInfo(dir).EnumerateFiles();
    
        // Order by size.
        var sort = from file in files
                   orderby file.Length descending
                   select file;
    
        // List files.
        foreach (var file in sort)
        {
            Console.Write(file.FullName);
            Console.Write(" ");
            Console.WriteLine(file.Length);
        }
    
        Console.ReadLine();
    }
