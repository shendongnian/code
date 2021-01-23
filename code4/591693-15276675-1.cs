    List<Folder> completeListOfFolderIds = new List<Folder>();
    //Fills list with all public folders and subfolders
    GetAllFolders(service, completeListOfFolderIds);
    foreach(Folder folder in completeListOfFolderIds)
    {
    ItemView itemView = new ItemView(int.MaxValue);
    FindItemsResults<Item> searchResults = service.FindItems(folder.Id, itemView);
    //do something with item list    
    }
