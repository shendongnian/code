    private IEnumerable<DocumentEntry> GetFolders(string id) {
    	if (IsLogged) {
    		var query = new FolderQuery(id)
    		{
    			ShowFolders = true
    		};
    
    		var feed = GoogleDocumentsService.Query(query);
    
    		return feed.Entries.Cast<DocumentEntry>().Where(x => x.IsFolder).OrderBy(x => x.Title.Text);
    	}
    
    	return null;
    }
    
        ...
    var rootFolders = GetFolders("root");
    if (rootFolders != null){
        foreach(var folder in rootFolders){
        	var subFolders = GetFolders(folder.ResourceId);
        	...
        }
    }
