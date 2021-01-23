    static IEnumerable<BuyerEarning> GetBuyer(bool acceptedOnly)
    {
        var collectTo = DateTime.Now.AddDays(-1).DayEnd();
        var collectFrom = collectTo.AddDays(-29).DayStart();
        using (var uow = new UnitOfWork(ConnectionString.PaydayLenders))
        {
            var r = new Repository<MatchHistory>(uow.Context);
            IQueryable<MatchHistory> results = r.Find()
                .Where(x =>
                    x.CreatedOn <= collectTo &&
                    x.CreatedOn >= collectFrom);
            
            if (acceptedOnly)
            {
                results = results
                    .Where(x => x.ResultTypeId == (int)MatchResultType.Accepted);
            }
            return results
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
