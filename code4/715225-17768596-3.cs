    void Test()	
    {
    	BrickTable bTable = new BrickTable();
    
    	bTable.Title	= "";
    	bTable.Value	= 23039;
    	bTable.X			= 18400;
    	bTable.Y			= 64;
    	
    	
    	List<string> items = new List<string>();
    	items.Add("Item1");
    	items.Add("Item5");
    	
    	bTable.Items = items;
    	
    	SerializeObject("BrickSet.xml",bTable);
    }
