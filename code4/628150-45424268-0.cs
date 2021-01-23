    FolderId subfolderInfo;
    // Call Method
    bool folderExist = isFolderExist(exchange, "Folder1", out subfolderInfo);
    
    //Implementation 
    private bool isFolderExist(ExchangeService exchange, string subFolder, out FolderId subfolderInfo)
            {
                try
                {
                    FolderView view = new FolderView(100);
                    view.PropertySet = new PropertySet(BasePropertySet.IdOnly);
                    view.PropertySet.Add(FolderSchema.DisplayName);
                    view.Traversal = FolderTraversal.Deep;
                    FindFoldersResults findFolderResults = exchange.FindFolders(WellKnownFolderName.Root, view);
                    foreach (Folder folder in findFolderResults)
                    {
                        if (folder.DisplayName == subFolder)
                        {                        
                            subfolderInfo = folder.Id;
                            return true;
                        }
                    }
                }
                catch (Exception Ex)
                {
                   ...
                }          
                subfolderInfo = null;
                return false;
            }
