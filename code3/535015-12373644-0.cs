    DirectoryInfo[] directories = System.IO.Directory.GetDirectories(@"\\testnetwork\abc$",
                                   "*.*",
                                   SearchOption.AllDirectories);
    foreach (DirectoryInfo dir in directories)
    {
        try
        {
           Console.WriteLine(System.IO.Path.GetDirectoryName(f));
        }
        catch(Exception ex)
        {
           // report an error or something
        }
    }
