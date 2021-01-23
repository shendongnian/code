    List<Purchase> purchases = new List<Purchase>();
    var purchases = consumers.Select(x => new {
                                           Id = x.Id,
                                           IList<Purchases> Purchases = x.Purchases         
                                           })
                             .ToList()
                             .GroupBy(x => x.Id)
                             .Select( x => x.Aggregate((merged, next) => merged.Merge(next)))
                             .ToList();
