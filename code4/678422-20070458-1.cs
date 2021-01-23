    private string MapPath(string seedFile)
    {
        if(HttpContext.Current!=null)
            return HostingEnvironment.MapPath(seedFile);
    
        var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
        var directoryName = Path.GetDirectoryName(absolutePath);
        var path = Path.Combine(directoryName, ".." + seedFile.TrimStart('~').Replace('/','\\'));
    
        return path;
    }
