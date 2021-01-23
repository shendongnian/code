    var washingtonCustomers = customers.Where(c => c.Field<string>("Region") == "WA");
    var recentOrders = orders.Where(o => (DateTime)o["OrderDate"] >= cutoffDate);
    var query = washingtonCustomers.Join(recentOrders, 
                     c => c.Field<string>("CustomerID"),
                     o => o.Field<string>("CustomerID"),
                     (c, o) => new { 
                         CustomerID = c.Field<string>("CustomerID"), 
                         OrderID = o.Field<int>("OrderID") 
                     });
