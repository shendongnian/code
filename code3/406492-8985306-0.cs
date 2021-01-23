    public IQueryable<WebsiteOrderStatus> lol(string accountNumber) 
    { 
         db.WebsiteOrderStatus 
           .Where(x => x.AccountNumber == accountNumber && x.LastUpdatedStatus != 1) 
           .GroupBy(g => g.ItemNumber) 
           .Select(g => new WebsiteOrderStatus
                        { 
                             ItemNumber = g.Key, 
                             ItemName = g.First().ItemName, 
                             Quantity = g.Sum(p => p.Quantity) 
                        }); 
    }
