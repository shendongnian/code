    var picFolder = Windows.Storage.KnownFolders.PicturesLibrary;
    var options = new QueryOptions(CommonFileQuery.DefaultQuery,new List<string> { ".png", ".jpg" }) ;
    options.FolderDepth = FolderDepth.Deep;
        
    var query = picFolder.CreateFileQueryWithOptions(options);
    var files = await query.GetFilesAsync();
                
