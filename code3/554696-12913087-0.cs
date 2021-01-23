    var query = from customer in session.Query<Customer>()
                let order = customer.Order
                from orderline in order.Orderlines
                orderby orderlines.price
                select new
                {
                    CustomerId = customer.Id,
                    CustomerName = customer.Name,
                    OrderId = order.Id,
                    OrderLineId = orderline.Id,
                    Price = orderline.Price,
                };
    
    var results = query.ToLookup(a => a.CustomerId)
        .Select(g => new CustomerDto
        {
            Id = g.Key,
            CustomerName = g.First().CustomerName,
            OrderLines =  g.Select(a => new OrderLineDto(a.OrderLineId, a.Price)).ToList()
        }).ToList();
