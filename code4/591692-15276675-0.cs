    public void GetAllFolders(ExchangeService service, List<Folder> completeListOfFolderIds)
        {
            FolderView folderView = new FolderView(int.MaxValue);
            FindFoldersResults findFolderResults = service.FindFolders(WellKnownFolderName.PublicFoldersRoot, folderView);
            foreach (Folder folder in findFolderResults)
            {
                completeListOfFolderIds.Add(folder);
                FindAllSubFolders(service, folder.Id, completeListOfFolderIds);
            }
        }
    private void FindAllSubFolders(ExchangeService service, FolderId parentFolderId, List<Folder> completeListOfFolderIds)
        {
            //search for sub folders
            FolderView folderView = new FolderView(int.MaxValue);
            FindFoldersResults foundFolders = service.FindFolders(parentFolderId, folderView);
            // Add the list to the growing complete list
            completeListOfFolderIds.AddRange(foundFolders);
            // Now recurse
            foreach (Folder folder in foundFolders)
            {
                FindAllSubFolders(service, folder.Id, completeListOfFolderIds);
            }
        }
