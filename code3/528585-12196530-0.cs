    public string IfFileExist(string value, string filename)   
    {   
        var folder = ApplicationData.Current.LocalFolder;   
        var getFilesAsync = folder.GetFilesAsync(CommonFileQuery.OrderByName).Result;
       
        var file = getFilesAsync.FirstOrDefault(x => x.Name == filename);   
        if (file != null)   
        {   
            return "ms-appdata:///local/" + filename;   
        }   
        return value;   
    }
