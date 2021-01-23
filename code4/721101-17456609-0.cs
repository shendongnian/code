    void SetText(string attribute, string attName, string value)
    {
    	// Get a collection of all the tags with name "input";
    	GeckoElementCollection tagsCollection = geckoWebBrowser1.Document.GetElementsByTagName("input");
    
    	foreach (GeckoElement currentTag in tagsCollection)
    	{
    		// If the attribute of the current tag has the name attName
    		if (currentTag.GetAttribute(attribute).Equals(attName))
    		{
    			// Then set its attribute "value".
    			currentTag.SetAttribute("value", value);
    			currentTag.Focus();
    		}
    	}
    }
