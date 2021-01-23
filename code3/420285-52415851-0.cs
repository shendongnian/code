    using (var connection = new SqlCeConnection(connectionString))
    {			
        var orderDictionary = new Dictionary<int, Order>();
    
        var list = connection.Query<Order, OrderDetail, Order>(
            sql,
            (order, orderDetail) =>
            {
                Order orderEntry;
    
                if (!orderDictionary.TryGetValue(order.OrderID, out orderEntry))
                {
                    orderEntry = order;
                    orderEntry.OrderDetails = new List<OrderDetail>();
                    orderDictionary.Add(orderEntry.OrderID, orderEntry);
                }
    
                orderEntry.OrderDetails.Add(orderDetail);
                return orderEntry;
            },
            splitOn: "OrderDetailID")
        .Distinct()
        .ToList();
    }
