    void Process (ActionState state)
    {
    	var orderItemQuery = from OrderItem item in order.OrderItems
    						   orderby item.OrderLineNumber ascending
    						   select item;
    						   
    	IEnumerable<ActionData> actionDatas = null;
    	
    	if (state ==  ActionState.Prepare)
    	{
    		var productIds = orderItemQuery.Select(o => o.ProductId).ToArray();
    		actionDatas = db.ActionDataTable.Where(a => productIds.Contains(a.ObjectId));
    	}
        else if(state == ActionState.QualityCheck)
    	{
    		var orderItemIds = orderItemQuery.Select(o => o.OrderItemId).ToArray();
    		actionDatas = db.ActionDataTable.Where(a => orderItemIds.Contains(a.ObjectId));
    	}
    	else
    	{
    		throw new InvalidOperationException();
    	}
    
    		// Do stuff against the complete list of actionDatas without requerying.
    	}
    }
