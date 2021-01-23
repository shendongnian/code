    string parentFolderId = @"/webdav/MyPublication/Building%20Blocks";
    
    var client = GetCoreServiceClient();
    
    if (!client.IsExistingObject(parentFolderId + "/AAA"))
    {
       var folder = client.GetDefaultData(2, parentFolderId);
       folder.Title = "AAA";
       client.Save(folder);
       // Create the other folders and components here
    }
