    public static Node[] GetVisibleDescendants(int parentId)
    {
    	using (var db = new Models.Database())
    	{
    		int[] visibleLeaves = SuperSecretResourceManager.GetLeavesForCurrentUserLol();
    
    		var targetQuery = db.Nodes as IQueryable<Node>;
    
    		targetQuery = targetQuery.Where(node =>
    				node.ParentNodeID == parentId &&
    				db.DescendantsOf(node.NodeID).Any(x => 
                                    visibleLeaves.Any(y => x.LeafID == y)));
    
    		// Notice, still an IQueryable.  Perform whatever processing is required.
    		SortByCurrentUsersSavedSettings(targetQuery);
    
    		return targetQuery.ToArray();
    	}
    }
