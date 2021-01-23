    foreach (var file in new DirectoryInfo(@"C:\Folder").GetFiles())
    {
        try
        {
            file.OpenRead();
        }
        catch
        {
            continue;
        }
        Console.WriteLine(file.Name);
    }
