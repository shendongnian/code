    using System.Text; 
    (...)
    public string ListAllItems()
    {
    	StringBuilder allItems = new StringBuilder();
    
    	foreach(CItem itm in Items){
    		allItems.AppendLine(itm.displayInfo());
    	} 
    
    	return allItems.ToString();      
    }
