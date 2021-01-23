    static IEnumerable<BuyerEarning> GetBuyerEPA()
    {
        var collectTo = DateTime.Now.AddDays(-1).DayEnd();
        var collectFrom = collectTo.AddDays(-29).DayStart();
        using (var uow = new UnitOfWork(ConnectionString.PaydayLenders))
        {
            var r = new Repository<MatchHistory>(uow.Context);
            return r.Find()
                .Where(x =>
                    x.CreatedOn <= collectTo &&
                    x.CreatedOn >= collectFrom)
                .GroupBy(x => new
                {
                    x.BuyerId,
                    x.TreeId,
                    x.TierId
                })
                .Select(x => new BuyerEarning(
                    x.Key.BuyerId,
                    x.Key.TreeId,
                    x.Key.TierId,
                    x.Average(y => y.Commission), //EPL
                    x.Where(y => y.ResultTypeId == (int)MatchResultType.Accepted)
                        .Average(y => y.Commission)) //EPA
                .ToList();
        }
    }
