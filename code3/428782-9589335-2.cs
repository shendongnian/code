    foreach(var dir in new DirectoryInfo (@"D:\longpaths")
                         .GetFileSystemInfos("*.*", SearchOption.AllDirectories))
    {
        try
        {
            Console.WriteLine(dir.FullName);
        }
        catch (PathTooLongException)
        {
                    FieldInfo fld = typeof(FileSystemInfo).GetField(
                                            "FullPath", 
                                             BindingFlags.Instance | 
                                             BindingFlags.NonPublic);
                    Console.WriteLine(fld.GetValue(dir));  // outputs your long path
        }
    }
