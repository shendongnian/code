    var cust = new Customer();
    ctx.Customers.InsertOnSubmit(cust);
    cust.Orders.Add(new Order { Quantity = 1, Part = "abc" } );
    cust.Orders.Add(new Order { Quantity = 1, Part = "def" });
    ctx.SubmitChanges();
