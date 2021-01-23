    public void ChangeNode(string name, string filePath)
    {
    
    	XDocument xDocument;
    	using (var streamReader = new StreamReader(filePath))
    	{
    		xDocument = XDocument.Parse(streamReader.ReadToEnd());
    	}
    
    	var nodes = xDocument.Descendants("Launch.File");
    
    	foreach (var node in nodes)
    	{
    		var nameNode = node.Descendants("Name").FirstOrDefault();
    
    		if (nameNode != null && nameNode.Value == name)
    		{
    			var disabledNode = node.Descendants("Disabled").FirstOrDefault();
    
    			if (disabledNode != null)
    			{
    				disabledNode.SetValue("True");
    			}
    		}
    	}
    
    	using (var streamWriter = new StreamWriter(filePath))
    	{
    		xDocument.Save(streamWriter);				
    	}
    }
