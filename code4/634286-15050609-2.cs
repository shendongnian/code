    protected void rptDummy_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	int itemsCount = ((List<SomeClass>)rptDummy.DataSource).Count;
    
    	if (e.Item.ItemType == ListItemType.Item)
    	{ 
    		if(e.Item.ItemIndex == itemsCount - 1)
    		{
    			//Do Things here
    		}
    	}
    }
