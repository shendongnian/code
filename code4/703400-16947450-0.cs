    public static class TreeViewEx
    {
    	public static List<TreeNode> GetAllNodes(this TreeNode Node)
    	{
    		List<TreeNode> list = new List<TreeNode>();
    		list.Add(Node);
    		foreach (TreeNode n in Node.Nodes)
    		list.AddRange(GetAllNodes(n));
    		return list;
    	}
    }
