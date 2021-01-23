    var epaFilter = new Func<MatchHistory, bool>(x => x.ResultTypeId == (int)MatchResultType.Accepted &&      x.CreatedOn <= collectTo &&                    x.CreatedOn >= collectFrom);
    var eplFilter = new Func<MatchHistory, bool>(x => x.CreatedOn <= collectTo && x.CreatedOn >= collectFrom);        
                 
    private static IEnumerable<MatchHistory> GetBuyerByFilter(Func<MatchHistory,Boolean> filter)
    {
        var collectTo = DateTime.Now.AddDays(-1).DayEnd();
        var collectFrom = collectTo.AddDays(-29).DayStart();
    
        using (var uow = new UnitOfWork(ConnectionString.PaydayLenders))
        {
            var r = new Repository<MatchHistory>(uow.Context);
    
            return r.Find()
                .Where(filter)
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
