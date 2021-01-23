    //Example :
    AutomationElement element = FindFirstDescendant( 
    	AutomationElement.FromHandle(windows_hWnd), 
    	(ele)=>Regex.IsMatch( ele.Current.Name, pattern)
    );
    
    //The generic method to find a descendant element:
    public static AutomationElement FindFirstDescendant(AutomationElement element, Func<AutomationElement, bool> condition) {
    	var walker = TreeWalker.ControlViewWalker;
		element = walker.GetFirstChild(element);
    	while (element != null) {
    		if (condition(element))
    			return element;
    		var subElement = FindFirstDescendant(element, condition);
    		if (subElement != null)
    			return subElement;
    		element = walker.GetNextSibling(element);
    	}
    	return null;
    }
