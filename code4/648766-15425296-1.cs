    public void ReadXml(XmlReader reader)
    {
    	var nodeType = reader.MoveToContent();
    	if (nodeType == XmlNodeType.Element)
    	{
    	    switch (reader.LocalName)
    		{
    			case "id":
    			case "code": ID = int.Parse(reader.Value); break;
    			default: break;
    		}
    	}
    }
