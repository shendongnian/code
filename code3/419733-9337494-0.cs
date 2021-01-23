    var query =
        from customer in Context.Customers
        where customer.Id == YourCustomerId // 1
        select new
        {
            Customer = customer,
            OrderCount = customer.Orders.Where(order => order.IsOpen).Count() // 2
        };
