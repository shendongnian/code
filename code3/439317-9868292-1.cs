    gv.ItemDataBound+=(s,ev)=>
    	{
    		if(ev.Item.ItemType==ListItemType.Header)
    		{
    			((ImageButton)ev.Item.Cells[??].Controls[0]).ImageUrl="SomePath";
    		}
    	};
