    Private List<TreeNode> _matchingNodes; 
    
    // Process the TreeView.
    private void ProcessTreeView(TreeView treeView, String FindText)
    {
       _matchingNodes = new List<TreeNode>();
     
      // Process each node recursively.
       foreach (TreeNode n in treeView.Nodes)
       {
          if(n.Text.Contains(FindText))
    		_matchingNodes.Add(n);
    
          ProcessRecursive(n, FindText);
       }
    
    }
    
    private void ProcessRecursive(TreeNode treeNode, String FindText)
    {
     
      // Process each node recursively.
       foreach (TreeNode n in treeNode.Nodes)
       {
    	  if(n.Text.Contains(FindText))
    		_matchingNodes.Add(n);
    
          ProcessRecursive(n, FindText);
       }
    }
