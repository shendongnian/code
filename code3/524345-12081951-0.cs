    string name = string.Empty;
    foreach (XmlNode ls in list.GetListCollection().ChildNodes)
    {
    	//Check whether list is document library
    	if (Convert.ToInt32(ls.Attributes["ServerTemplate"].Value) != 0x65)
    	{
    		continue;
    	}
    
    	string defaultViewUrl = Convert.ToString(ls.Attributes["DefaultViewUrl"].Value);
    	
    	if (defaultViewUrl.Contains(listName))
    	{
    		name = ls.Attributes["Name"].Value;
    		break;
    	}
    }
    
    XmlNode ndListItems = list.GetListItems(name, null, ndQuery, ndViewFields, null, ndQueryOptions, null);
    XmlNodeList oNodes = ndListItems.ChildNodes;
    
    // rest of processing below...
