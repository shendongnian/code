    IEnumerable<Order> filteredOrders; // or IList<Order>, etc., as your prefer
    
    switch (order.type.ToString())
    {
        case "Rush":
            filteredOrders = db.Orders.Where(a => a.rushID == order.rushID).ToList();
        case "Standard":
            filteredOrders = db.Orders.Where(a => a.standardID == order.standardID).ToList();
        default::
            return HttpNotFound();
    }
    
    var viewModel = new OrderDetailsViewModel
    {
        PastOrders = filteredOrders,
        Order = order;
    };
