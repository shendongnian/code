    public IQueryable<IGrouping<Int32?, WebsiteOrderStatus>> lol(string accountNumber)
    {
         db.WebsiteOrderStatus
           .Where(x => x.AccountNumber == accountNumber && x.LastUpdatedStatus != 1)
           .GroupBy(g => g.ItemNumber)
           .Select(g => new
                        {
                             ItemNumber = g.Key,
                             ItemName = g.First().ItemName,
                             Count = g.Sum(item => item.Quantity)
                        });
     }
