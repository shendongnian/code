    var query = db.Customers
                  .Where(c => c.OrderCount > 500) // Or whatever query you want
                  .Select(c => new { c.Name, c.FirstOrder })
                  .AsEnumerable() // Do the rest of the query on the client
                  .Select(c => new { c.Name, c.Month = c.FirstOrder.ToString("MMM") });
