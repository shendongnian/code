    var orderQuery = order.OrderItems.Orderby(o=>o.OrderLineNumber);
    var actionDataQuery = state == ActionState.Prepare
             ?orderQuery.Join(db.ActionDataTable, o=>o.ProductId, ad=>ad.ObjectId, (o,ad)=>new {order = o,actionData = ad})
             :state == QualityCheck
                  ?ActionState.orderQuery.Join(db.ActionDataTable, o=>o.OrderItemId, ad=>ad.ObjectId, (o,ad)=>new {order = o,actionData = ad})
                  :null;
    if(actionDataQuery == null)
          throw new InvalidOperationException();
    foreach(var orderWithActionData in actionDataQuery)
    {
         ///do something
    }
