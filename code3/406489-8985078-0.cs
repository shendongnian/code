    db.WebsiteOrderStatus
       .Where(x => x.AccountNumber == accountNumber && x.LastUpdatedStatus != 1)
       .GroupBy(g => new { g.ItemNumber, g.ItemName })
       .Select(g => new
                    {
                         ItemNumber = g.Key.ItemNumber,
                         ItemName = g.Key.ItemName,
                         Count = g.Sum(item => item.Quantity)
                    });
