    var dbOrder = new Order
    {
       OrderID = order.OrderID,
       Description = order.OrderDescription,
       Employee = context.Employees.SingleOrDefault(x => x.EmployeeID == order.EmployeeID),
    }
    //this adds the relationship to the child without adding a new child record - perfect!
    foreach(var p in order.ProductsList)
    {
       dbOrder.Products.Add(p);
    }
    context.AddToOrders(dbOrder);
    context.SaveChanges();
