    var myOrders = customers
      .Where(c => c.Field<string>("Region")=="WA")
      .Select(c => 
        orders
          .Where(o =>
            (o.Field<string>("CustomerID") == c.Field<string>("CustomerID"))
            && ((DateTime)o["OrderDate"] > cutoffDate))
          .Select(o => 
             new {
               CustomerID = c.Field<string>("CustomerID"),
               OrderID = o.Field<int>("OrderID")
             })
       );
      
