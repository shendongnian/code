    DirectoryInfo[] directories = System.IO.Directory.GetDirectories(@"\\testnetwork\abc$",
                               "*.*",
                               SearchOption.AllDirectories);
    foreach (DirectoryInfo dir in directories)
    {
    try
    {
    Console.WriteLine(System.IO.Path.GetDirectoryName(f));
    }
    catch(UnauthorizedAccessException e)
    {
       // report an error for UnauthorizedAccessException
    }
    catch(Exception ex)
    {
    // other exception if
    }
    }
