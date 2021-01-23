    void Main()
    {	
        var dirs = new DirectoryInfo(Server.MapPath("~/Videos")).GetDirectories();
    	CreateTree(videoMenu.Items, dirs):
    }
    
    public void CreateTree(IList<RadMenuItem> parantCollection, IEnumerable<DirectoryInfo> parentDirs)
    {
    	foreach (var dir in parentDirs)
    	{
    		var node = OutputDirectory(dir, null);
    		parantCollection.Add(node);
    		CreateTree(node.Items, dir.GetDirectories());
    	}
    }
