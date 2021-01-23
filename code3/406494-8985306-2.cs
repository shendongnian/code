    public IQueryable<OrderStatus> lol(string accountNumber) 
    { 
         db.WebsiteOrderStatus 
           .Where(order => order.AccountNumber == accountNumber && order.LastUpdatedStatus != 1) 
           .GroupBy(order => order.ItemNumber) 
           .Select(grouping => new OrderStatus //This is your custom class, for binding only
                        { 
                             ItemNumber = grouping.Key, 
                             ItemName = grouping.First().ItemName, 
                             Quantity = grouping.Sum(order => order.Quantity) 
                        }); 
    }
