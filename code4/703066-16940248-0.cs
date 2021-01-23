    XmlDocument oXml = new XmlDocument();
    oXml.Load(Path);
    
    //Get a list of Head nodes. For each one of these, create an `OtherObject`
    XmlNodeList headNodes = oXml.SelectNodes("//Head");
    
    foreach(XmlNode headNode in headNodes)
    {
        //Get a list of the child 'Node' nodes
    	XmlNodeList childNodes = headNode.SelectNodes("./Node");
    	
    	if(childNodes.Count == 2)
    	{
    	   Object firstObject = new Object() { 
    											Name = childNodes[0].Attributes["Name"].Value,
    											Key = childNodes[0].Attributes["Key"].Value 
    										 };
    										 
    	   Object secondObject = new Object() { 
    											Name = childNodes[1].Attributes["Name"].Value,
    											Key = childNodes[1].Attributes["Key"].Value 
    										 };										 
    	
    		OtherObject oOther = new OtherObject(firstObject, secondObject);
    	
    	}
    	
    
    }
