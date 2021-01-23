    var query = Directory.GetFiles(LRSettings.Default.OperatingDirectory, LRSettings.Default.FileExtension, SearchOption.AllDirectories)
    		.AsQueryable()
    		.Select(Filename => new { Filename, new FileInfo(Filename).LastWriteTime, new FileInfo(Filename).Extension, new FileInfo(Filename).Length });
    
    if(whereclause != string.Empty) 
    {
        query = query.Where(whereclause);
    }
