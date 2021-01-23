    static IEnumerable<BuyerEarning> GetXXXX(Func<MatchHistory, bool> predicate = null)
    {
        var collectTo = DateTime.Now.AddDays(-1).DayEnd();
        var collectFrom = collectTo.AddDays(-29).DayStart();
    
        using (var uow = new UnitOfWork(ConnectionString.PaydayLenders))
        {
            var r = new Repository<MatchHistory>(uow.Context);
    
            var filtered = r.Find()
                            .Where(x.CreatedOn <= collectTo && x.CreatedOn >= collectFrom);
    
            if(predicate != null)
                filtered = filtered.Where(predicate);
    
            return filtered 
                .GroupBy(x => new
                {
                    x.BuyerId,
                    x.TreeId,
                    x.TierId
                })
                .ToList()
                .Select(x => new BuyerEarning(
                    x.Key.BuyerId,
                    x.Key.TreeId,
                    x.Key.TierId,
                    x.Average(y => y.Commission)))
                .ToList();
        }
    }
