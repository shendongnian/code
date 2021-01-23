    var myOrders = customers
      .Where(c => c.Region == "WA")
      .SelectMany(c => 
        orders
          .Where(o => (o.CustomerID == c.CustomerID)
            && (o.OrderDate > cutoffDate))
          .Select(o => new {
               CustomerID = c.CustomerID,
               OrderID = o.OrderID
             })
       );
      
