    using (var ctx = new EFTestDBEntities())
    {
        var results = from x in ctx.MyTables
                      let TheTotal = ctx.MyTables.Sum(y => ConvertToDecimal(y.Price))
                      select new
                      {
                          ID = x.ID,
                          // the following three values are stored as strings in DB
                          Price = ConvertToDecimal(x.Price),
                          Quantity = ConvertToInt32(x.Quantity),
                          Amount = x.Amount,
                          TheTotal
                      };
    }
