	var destinations = new List<int> { 414, 416 };
	var query = from order in GroupOrder.Include(o => o.DestinationGroupItem) // this is the join via the navigation property
				where order.OrderId == 5662 && destinations.Contain(order.DestinationGroupItem.DestinationId)
				select order;
	// OR
	var query = dataContext.GroupOrder
				.Include(o => o.DestinationGroupItem)
				.Where(order => order.OrderId == 5662 && destinations.Contain(order.DestinationGroupItem.DestinationId));
