    public void RemoveNodeModelByGuid(NodeModel root, Guid guid)
    {
    	Stack<NodeModel> nodes = new Stack<NodeModel>();
    	nodes.Add(root);
    
    	while (nodes.Count > 0)
    	{
    		var currentNode = nodes.Pop();
    		for (int i = currentNode.Children.Count - 1; i >= 0; i--)
    		{
    			if (currentNode.Children[i].Id == guid)
    				currentNode.Children.RemoveAt(i);
    			else
    				nodes.Push(currentNode.Children[i]);
    		}
    	}
    }
