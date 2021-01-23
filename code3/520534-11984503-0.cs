    public List<string> GetSelectedNodes()
    {
	    var listNodes = new List<string>();
    	foreach (Node node in this.Nodes)
	    {
		    if (node.IsChecked == null)
    		{
			    this.GetSelectedChildNodeText(node.Text, node.Children, ref listNodes);
		    }
    		else if (node.IsChecked == true)
		    {
			    listNodes.Add(node.Text);
		    }
	    }
    
	    return listNodes;
    }
    
    private void GetSelectedChildNodeText(string nodeName, IEnumerable<Node> nodes, ref List<string> listNodes)
    {
	    foreach (Node node in nodes)
    	{
		    string currentName = string.Format("{0}_{1}", nodeName, node.Text);
    		if (node.IsChecked == null)
		    {
			    this.GetSelectedChildNodeText(currentName, node.Children, ref listNodes);
		    }
    		else if (node.IsChecked == true)
		    {
			    listNodes.Add(currentName);
		    }
	    }
    }
