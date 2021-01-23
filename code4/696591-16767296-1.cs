    private TreeNode FindMatchedNode(TreeNodeCollection tnCol, string text)
    {
    	TreeNode tn = null;
    
    	foreach (TreeNode node in tnCol)
    	{
    		if (text.ToLower().Contains(node.Text.ToLower()))
    		{
    			tn = node;
    			break;
    		}
    		else if (node.Nodes != null)
    		{
    			tn = FindNode(node.Nodes, text);
    
    			if (tn != null)
    				break;
    		}
    	}
    
    	return tn;
    }
