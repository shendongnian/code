    gv.ItemDataBound+=(s,ev)=>
    	{
    		if(ev.Item.ItemType==ListItemType.Header)
    		{
    			((Image)ev.Item.FindControl("imgSelectAll")).ImageUrl="SomePath";
    		}
    	};
