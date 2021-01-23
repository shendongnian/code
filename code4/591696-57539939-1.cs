    List<Folder> completeListOfFolderIds = new List<Folder>();
    GetAllFolders(service, completeListOfFolderIds);
    foreach (Folder folder in completeListOfFolderIds)
    {
        List<Item> results = GetItems(service, folder);
    }
    
    public void GetAllFolders(ExchangeService service, List<Folder> completeListOfFolderIds)
    {
        ExtendedPropertyDefinition isHiddenProp = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.Boolean);
        FolderView folderView = new FolderView(int.MaxValue);
        folderView.PropertySet = new PropertySet(isHiddenProp,FolderSchema.DisplayName, FolderSchema.Id, FolderSchema.ChildFolderCount, FolderSchema.TotalCount, FolderSchema.ParentFolderId, FolderSchema.WellKnownFolderName);
        List<SearchFilter> searchFilterCollection = new List<SearchFilter>();
        searchFilterCollection.Add(new SearchFilter.IsEqualTo(isHiddenProp, false));
        SearchFilter searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, searchFilterCollection.ToArray());
        Folder rootfolder = Folder.Bind(service, WellKnownFolderName.MsgFolderRoot);
        // Indicate a Traversal value of Deep, so that all subfolders are retrieved.
        folderView.Traversal = FolderTraversal.Deep;
        rootfolder.Load();
        //FindFoldersResults findFolderResults = service.FindFolders(WellKnownFolderName.MsgFolderRoot, folderView);
        FindFoldersResults findFolderResults = rootfolder.FindFolders(searchFilter, folderView);
        foreach (Folder folder in findFolderResults)
        {
            completeListOfFolderIds.Add(folder);
            //List<Item> results = GetItems(service, folder);
            FindAllSubFolders(service, folder.Id, completeListOfFolderIds);                
        }
    }
       
    private void FindAllSubFolders(ExchangeService service, FolderId parentFolderId, List<Folder> completeListOfFolderIds)
    {
        FolderView folderView = new FolderView(int.MaxValue);
        FindFoldersResults foundFolders = service.FindFolders(parentFolderId, folderView);
        completeListOfFolderIds.AddRange(foundFolders);
        // Now recurse
        foreach (Folder folder in foundFolders)
        {
            FindAllSubFolders(service, folder.Id, completeListOfFolderIds);
        }
    }
    private List<Item> GetItems(ExchangeService service ,Folder folder)
    {
        if (service == null)
        {
            return null;
        }
        List<Item> items = new List<Item>();
        PropertySet propertySet = new PropertySet(BasePropertySet.FirstClassProperties);
        const Int32 pageSize = 50;
        ItemView itemView = new ItemView(pageSize);
        itemView.PropertySet = propertySet;
        FindItemsResults<Item> searchResults = null;
        try
        {
            do
            {                    
                searchResults = service.FindItems(folder.Id,itemView);
                items.AddRange(searchResults.Items);
                itemView.Offset += pageSize;
            } while (searchResults.MoreAvailable);
        }
        catch (Exception ex)
        {                
        }
        return items;
    }
