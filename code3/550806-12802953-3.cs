    if(state!=ActionState.Prepare&&state!=ActionState.QualityCheck)
        throw new InvalidOperationException();
    var orderSelector = state == ActionState.Prepare
                                 ?o=>o.ProductId
                                 :?o=>o.OrderItemId
    var orderWithActionQuery  = order.OrderItems.Orderby(o => o.OrderLineNumber).GroupJoin(
			db.ActionDataTable,
			orderSelector,
			ad => ad.ObjectId,
			(x, y) => new { item = x, actionDatas = y })
			.SelectMany(
				x => x.actionDatas.FirstOrDefault(),
				(x, y) => new { item = x.item, actionData = y });    
    foreach(var orderWithActionData in orderWithActionQuery)
    {
         //orderWithActionData.item is orderItem
         //orderWithActionData.actionData is ation data of this item
    }
