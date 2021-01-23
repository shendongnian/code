	var roots = myList.Where(x => x.ParentId == null);
	foreach (var root in roots)
	{
		AddNode(null, root, myList);
	}
	private void AddNode(TreeNodeCollection nodes, Node current, IList<Node> items)
	{
		if (nodes == null)
		{
			nodes = myTree.Nodes;
		}
		
		...
	}
