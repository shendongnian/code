    Customers.Select(c =>
        new Customer
        {
            Orders = c.Orders.Select(o =>
                new Order
                {
                    Order_Details = o.Order_Details
                });
        });
