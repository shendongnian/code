    public async Task<System.Collections.Generic.IReadOnlyList<Windows.Storage.StorageFile>> GetFilesAsync()
    {
        var folder = ApplicationData.Current.LocalFolder;
        return await folder.GetFilesAsync(CommonFileQuery.OrderByName)
                           .AsTask().ConfigureAwait(false);
    }
    public string IfFileExist(string value, string filename)   
    {   
        var files = GetFilesAsync().Result;
       
        var file = files.FirstOrDefault(x => x.Name == filename);   
        if (file != null)   
        {   
            return "ms-appdata:///local/" + filename;   
        }   
        return value;   
    }
