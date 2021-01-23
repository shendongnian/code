    var myOrder= db.Orders.Include("OrderItems")
                 .Where(x => x.OrderId == 3)  
                 .Select(o => new {
                     order = o,
                     orderItems = o.OrderItems.OrderBy(i => i.sequence)
                 }).FirstOrDefault();
    // Usage
    myOrder.order; // Order
    myOrder.order.OrderItems; // OrderItems
    myorder.orderItems;  // OrderItems alternative
