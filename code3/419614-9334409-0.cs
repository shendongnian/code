    var orders = from o in dataContext.OrdersView
             group o by new { o.ID, o.Name, o.Category } into grouping
             let orderDate = grouping.Min(order => order.OrderDate)
             let deliveryDate = grouping.Min(order => order.DeliveryDate)
             select new Order() {
               ID = grouping.Key.ID,
               Name = grouping.Key.Name,
               Category = grouping.Key.Category,
               OrderDate = orderDate,
               DeliveryDate = deliveryDate
             };
