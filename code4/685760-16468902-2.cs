    public TermDocMatrix(string IndexPath,string FileName)
    {
        if (!Directory.Exists(IndexPath)) Directory.CreateDirectory(IndexPath);
        LogManager.Configure(System.IO.Path.Combine(_Path, _FileName + ".txt"), false);
        // read all files
        LoadFiles();
    }
