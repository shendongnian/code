     public IQueryable<WebsiteOrderStatus> lol(string accountNumber)
     {
         return db.WebsiteOrderStatus
            .Where(x => x.AccountNumber == accountNumber && x.LastUpdatedStatus != 1)
            .GroupBy(g => g.ItemNumber)
            .Select(g => 
                    new WebsiteOrderStatus 
                    {
                         ItemNumber = g.Key,
                         ItemName = g.First().ItemName,
                         Quantity = g.Sum(g => g.Quantity)
                    }
            );
     }
