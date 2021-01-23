    private List<LabelCountry> addedElements = new List<LabelCountry>();
    void flcl_Selection(object sender, MyEventArgs e)
    {
    	//remove old items
    	foreach(LabelCountry element in addedElements)
    	{
    		MainGrid.Children.Remove(element);
    	}
    	addedElements.Clear();
    	// add new items
    	for (int i = 0; i < e.MyFirstString.Count; i ++)
    	{
    		LabelCountry lbl = new LabelCountry((string)e.MyFirstString[i]);
    		addedElements.Add(lbl)
    		MainGrid.Children.Add(lbl);
    	}
    }
