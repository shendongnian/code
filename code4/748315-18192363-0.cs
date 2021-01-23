    var result = Inventory.Join(StockTransactions, x=>x.Id, x=>x.ItemId,(x,y)=>new {x,y})
                          .GroupBy(a=>new {a.x.Id, a.x.Title})
                          .SelectMany(a=>
                             new {
                                    a.Key.Id,
                                    a.Key.Title,
                                    sold = a.Sum(b=> b.y.transactiontype == 1 ? b.y.MovedQuantity : 0),
                                    Revenue = a.Sum(b=>b.y.transactiontype == 1 ? b.y.MovedQuantity * b.y.UnitPrice : 0),
                                    distributed = a.Sum(b=> b.y.transactiontype == 0 ? b.y.MovedQuantity : 0)                       
                                 });
                       
                              
                          
