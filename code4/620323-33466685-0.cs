    Items = Items.OrderBy(i => i.Type).ToList();
    
    for (var j = 0; j < Items.Count - 1; j++) // ordering ThenBy() AOT workaround
    {
    	for (var i = 0; i < Items.Count - 1; i++) 
    	{
    		if (Items[i].Type == Items[i + 1].Type && Items[i].Price > Items[i + 1].Price)
    		{
    			var temp = Items[i];
    
    			Items[i] = Items[i + 1];
    			Items[i + 1] = temp;
    		}
    	}
    }
