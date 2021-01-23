    private FolderData GetOrCreateFolder(string folderPath, SessionAwareCoreServiceClient client)
    {
        ReadOptions readOptions = new ReadOptions();
    
        if (client.IsExistingObject(folderPath))
        {
            return client.Read(folderPath, readOptions) as FolderData;
        }
        else
        {
            int lastSlashIdx = folderPath.LastIndexOf("/");
            string newFolder = folderPath.Substring(lastSlashIdx + 1);
            string parentFolder = folderPath.Substring(0, lastSlashIdx);
            FolderData parentFolderData = GetOrCreateFolder(parentFolder, client);
            FolderData newFolderData = client.GetDefaultData(ItemType.Folder, parentFolderData.Id) as FolderData;
            newFolderData.Title = newFolder;
    
            return client.Save(newFolderData, readOptions) as FolderData;
        }
    }
