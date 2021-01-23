    var query = Context.Customers
                       .Where(c => c.CustomerId == SelectedCustomer.CustomerId)
                       .SelectMany(c => c.Orders)
                       .Select(o => new { 
                                  OrderId = o.OrderId, 
                                  LatestDate = o.Statuses.Max(s => s.StatusDate) });
                   .
                                 
