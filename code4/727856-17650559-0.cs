    StorageFolder installedLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
    StorageFolder subFolder = await installedLocation.GetFolderAsync("Assets");
    subFolder = await subFolder.GetFolderAsync("Images");
    List<String> fileType = new List<String>();
    fileType.Add(".jpg");
    var queryOptions = new QueryOptions(CommonFileQuery.DefaultQuery, fileType);
    var query = subFolder.CreateFileQueryWithOptions(queryOptions);
    var fileList = await query.GetFilesAsync();
