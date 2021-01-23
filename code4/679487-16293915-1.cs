    bool dirExists = System.IO.Directory.Exists(dir);
    if(!dirExists)
        System.IO.Directory.CreateDirectory(dir);
    using(var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
    {
    
    }
