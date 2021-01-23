    void Process (ActionState state)
    {
        var orderItemQuery = from OrderItem item in order.OrderItems
                               orderby item.OrderLineNumber ascending
                               select item;
        var orderItemWithActionDataQuery = 
                    from item in orderItemQuery
                    select new{Item = item,
                               ActionData = (
                        from ActionData ad in db.ActionDataTable
                          where ad.ObjectId == item.ProductId
                          select ad
                    ).First()};
    
            switch (state)
            {
                case ActionState.Prepare:
                    // done
                    break;
    
                case ActionState.QualityCheck:
                    orderItemWithActionDataQuery = 
                    from item in orderItemQuery
                    select new{Item = item,
                               ActionData = (
                        from ActionData ad in db.ActionDataTable
                          where ad.ObjectId == item.OrderItemId
                          select ad
                    ).First()};
    
                default:
                    throw new InvalidOperationException();
            }
    
    
    
        foreach (var combinedItem in orderItemWithActionDataQuery)
        {
            OrderItem item = combinedItem.Item;
            ActionData actionData = combinedItem.ActionData;
    
            // ...
        }
    }
