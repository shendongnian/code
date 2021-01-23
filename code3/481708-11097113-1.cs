    private static void AddElements(XElement rootPatch, XDocument runtimeDocument, XElement allUserElement)
    {
    	XElement patchElem = null;
    	if (allUserElement.Attribute("id") != null 
            && !string.IsNullOrWhiteSpace(allUserElement.Attribute("id").Value))
    	{
    		// find runtime element by id
                    XElement runtimeElement = (from e in runtimeDocument.Descendants(allUserElement.Name)
                                               where e.Attribute("id") != null 
                                                  && e.Attribute("id").Value.Equals(allUserElement.Attribute("id").Value)
                                               select e).FirstOrDefault();
                    // create new patch node
                    patchElem = new XElement("xmlpatch");
    
                    // check for changed attributes
                    foreach (var allUserAttribute in allUserElement.Attributes())
                    {
                        XAttribute runtimeAttribute = runtimeElement.Attribute(allUserAttribute.Name);
                        if (!allUserAttribute.Value.Equals(runtimeAttribute.Value))
                        {
                            patchElem.SetAttributeValue(allUserAttribute.Name, runtimeAttribute.Value);
                        }
                    }
    
                    // check for changed value
                    if (!allUserElement.HasElements && !allUserElement.Value.Equals(runtimeElement.Value))
                    {
                        patchElem.Value = runtimeElement.Value;
                    }
    	}
    
    	// loop through all children to find changed values
    	foreach (var childElement in allUserElement.Elements())
    	{
    		AddElements(rootPatch, runtimeDocument, childElement);
    	}
    
    	// add node for changed value
    	if (patchElem != null 
    		&& (patchElem.HasAttributes || !string.IsNullOrEmpty(patchElem.Value)))
    	{
                    patchElem.SetAttributeValue("targetId", allUserElement.Attribute("id").Value);
                    rootPatch.AddFirst(patchElem);
    	}
    }
