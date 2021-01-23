    var summaries = Customers.GroupJoin(Orders,
    	cst => cst.Id,
    	ord => ord.CustomerId,
    	(cst, ord) => new { Customer = cst, Orders = ord.DefaultIfEmpty() })
    	.SelectMany(c => c.Orders.Select(o => new
    		{
    			CustomerId = c.Customer.Id,
    			CustomerName = c.Customer.Name,
    			Categories = Categories.Where(cat => cat.Id == c.Customer.Id)
    		}));
