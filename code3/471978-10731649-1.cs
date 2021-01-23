    var Q = from Data in Context.Orders
            join D2 in Context.OrderDetails on Data.OrderID equals D2.OrderID
            group Data by Data into grouped
                           select new
                                  {
                                      OrderId = grouped.Key.OrderId,
                                      OrderDate = grouped.Key.OrderDate
                                      Shipping = grouped.Key.Shipping
                                      .
                                      .
                                      .
                                      Count = grouped.Count() 
                                  };
