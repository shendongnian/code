    int maxDepth = 3;
    private static INodeCollection NodesLookUp(string path, int level)
    {
       if(level >= maxDepth)
    		return null;
       var shareCollectionNode = new ShareCollection(path);
       // Do somethings
    
      foreach (var directory in Directory.GetDirectories(shareCollectionNode.FullPath))
       {
       	   var nodes = NodesLookUp(directory, level + 1);
    	   if(nodes != null)
           		shareCollectionNode.AddNode(nodes);
    
       }
       return shareCollectionNode;
    }
