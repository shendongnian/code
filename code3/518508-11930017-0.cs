    var withNull = new Invoice[] { null }.Concat(invoices);
    var withDifference = withNull.Zip(withNull.Skip(1),
                                      (x, y) => x == null ? y :
                                          new Invoice { 
                                              ID = y.ID,
                                              Total = y.Total,
                                              Date = y.Date,
                                              Difference = y.Total - x.Total
                                          }
                                      )
                                 .ToList();
