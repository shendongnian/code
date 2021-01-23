    public static IEnumerable<string> GetXmlFilesByLastWriteTime(string path)
    {
        var directoryInfo = new DirectoryInfo(path);
        if(!directoryInfo.Exists) return Enumerable.Empty<string>();
        
        var query = 
            from file in directoryInfo.GetFiles()
            where file.Extension.ToLower() == ".xml"
            orderby file.LastWriteTime
            select file.Name;
        
        return query;
    }
