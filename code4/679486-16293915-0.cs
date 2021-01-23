    bool IsExists = System.IO.Directory.Exists(dir);
    if(!IsExists)
        System.IO.Directory.CreateDirectory(dir);
    using(var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
    {
    
    }
