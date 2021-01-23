    public List<CodeElement> GetAllCodeElementsOfType(
    	CodeElements elements, 
    	vsCMElement elementType, 
    	
    	bool includeExternalTypes)
    {
    	var ret = new List<CodeElement>();
    	
    	foreach (CodeElement elem in elements)
    	{
    		// iterate all namespaces (even if they are external)
    		// > they might contain project code
    		if (elem.Kind == vsCMElement.vsCMElementNamespace)
    		{
    			ret.AddRange(
    				GetAllCodeElementsOfType(
    					((CodeNamespace)elem).Members, 
    					elementType, 
    					includeExternalTypes));
    		}
    		
    		// if its not a namespace but external
    		// > ignore it
    		else if (elem.InfoLocation == vsCMInfoLocation.vsCMInfoLocationExternal && !includeExternalTypes)
    			continue;
    			
    		// if its from the project
    		// > check its members
    		else if (elem.IsCodeType)
    		{
    			ret.AddRange(
    				GetAllCodeElementsOfType(
    					((CodeType)elem).Members, 
    					elementType, 
    					includeExternalTypes));
    		}
    
    		if (elem.Kind == elementType)
    			ret.Add(elem);
    	}
    	return ret;
    }
