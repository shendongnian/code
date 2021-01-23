    while (!xmlReader.EOF)
    {
    	switch(xmlReader.NodeType)
    	{
    		case XmlNodeType.Element:
    			switch(xmlReader.Name)
    			{
    				case "Header":
    					while (xmlReader.Name != "Timeseries" && xmlReader.Read()) // advance to next node
    					{
    						// read
    					}
    					break;
    				case "Timeseries":
    					while (xmlReader.Name != "Period" && xmlReader.Read()) // advance to next node
    					{
    						// read
    					}  
    					break;
    				case "Period":
    					while (xmlReader.Name != "Interval" && xmlReader.Read()) // advance to next node
    					{
    						// read
    					}
    					break;
    				case "Interval":
    					while (xmlReader.NodeType != XmlNodeType.EndElement && xmlReader.Read()) // advance to next node
    					{
    						// read
    					}
    					break;
    			}
    			break;
    			
    		case XmlNodeType.EndElement:
    			if(xmlReader.Name == "Period")
    			{
    				// write intervals
    			}
    			break;
    			
    		default:
    			xmlReader.Read(); // advance to next node
    			break;
    	}
    }
