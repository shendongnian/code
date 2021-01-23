    foreach(var custGroup in forecasts.Where(f => f.Year == DateTime.Now.Year).GroupBy(f => new { f.Customer, f.SalesPersonId }).Where(k => k.Count() > 1).Select(k => new { Customer = k.Key.Customer, SalesPersonId = k.Key.SalesPersonId, TotalAmount = k.Sum(x => x.Amount) } )
    {
               toReturn.Add(new MultipleCustomer(custGroup.Customer)
               {
                  Salesperson = custGroup.SalesPersonId,
                  Forecast = custGroup.TotalAmount
               });
           }
       }
    }
