    var result = from a in context.Orders
                 join b in (context.Orders.Where(o => o.ProductID == 5).GroupBy(o => o.CustomerID).Select(g => new { CustomerID = g.Key, Price = g.Max(o => o.Price)))
                     on new {a.CustomerID, a.Price} equals new {b.CustomerID, b.Price}
                 where a.ProductID == 5
                 select a.ID;
