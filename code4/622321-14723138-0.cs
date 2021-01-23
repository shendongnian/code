    SalesOrderDetails.Where(sod => sod.SalesOrderID == 71920)
                     .GroupBy(sod => sod.salesOrderID)
                     .Select(g => new {
                                   SalesOrderId = g.Key,
                                   TotalQty = g.Sum(i => Convert.ToDouble(i.OrderQty)),
                                   TotalPrice = g.Sum(i => i.UnitPrice)
                                  });
                            
