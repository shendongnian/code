    var query = Database.GetAllOrders()
                        .GroupBy(order => order.CustomerName)
                        .Select(orders => new { 
                            Customer = orders.Key,
                            Amount = orders.Sum(o => o.OrderLines.Sum(
                                                     l => l.Quantity * l.UnitPrice))
                        })
                        .OrderByDescending(x => x.Amount);
