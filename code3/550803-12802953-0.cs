    var orderQuery = order.OrderItems.Orderby(o=>o.OrderLineNumber);
    IEnumerable<ActionData> actionDataQuery = state == ActionState.Prepare
             ?orderQuery.Join(db.ActionDataTable, o=>o.ProductId, ad=>ad.ObjectId, (o,ad)=>ad)
             :state == QualityCheck
                  ?ActionState.orderQuery.Join(db.ActionDataTable, o=>o.OrderItemId, ad=>ad.ObjectId, (o,ad)=>ad)
                  :null;
    if(actionDataQuery == null)
          throw new InvalidOperationException();
    foreach(var actionData in actionDataQuery)
    {
         ///do something
    }
