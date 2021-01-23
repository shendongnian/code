    private List<TreeNode> FindAllMatchedNodes(TreeNodeCollection tnCol, string text)
    {
    	List<TreeNode> retVal = new List<TreeNode>();
    
    	foreach (TreeNode node in tnCol)
    	{
    		if (text.ToLower().Contains(node.Text.ToLower()))
    		{
    			retVal.Add(node);
    		}
    		else if (node.Nodes != null)
    		{
    			retVal.AddRange(FindNode(node.Nodes, text));
    		}
    	}
    
    	return retVal;
    }
