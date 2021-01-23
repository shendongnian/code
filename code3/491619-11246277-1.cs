    public List<Control> ListControlCollections(Page page, string propertyName)
    {
    	List<Control> controlList = new List<Control>();
        AddControls(page.Form.Controls, controlList, propertyName);
    	return controlList;
    }
    
    private void AddControls(ControlCollection controlCollection, List<Control> controlList, string propertyName)
    {
    	foreach (Control c in controlCollection) {
    		PropertyInfo propertyToFind = c.GetType().GetProperty(propertyName);
    
    		if (propertyToFind != null) {
    			controlList.Add(c);
    		}
    
    		if (c.HasControls()) {
    			AddControls(c.Controls, controlList, propertyName);
    		}
    	}
    }
