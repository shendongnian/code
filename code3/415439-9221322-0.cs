    private static string GetPath(this XPathNavigator navigator)
    {
    	StringBuilder path = new StringBuilder();
    	for (XmlNode node = navigator.UnderlyingObject as XmlNode; node != null; node = node.ParentNode)
    	{
    		string append = "/" + path;
    
    		if (node.ParentNode != null && node.ParentNode.ChildNodes.Count > 1)
    		{
    			append += "[";
    
    			int index = 1;
    			while (node.PreviousSibling != null)
    			{
    				index++;
    			}
    
    			append += "]";
    		}
    
    		path.Insert(0, append);
    	}
    
    	return path.ToString();
    }
