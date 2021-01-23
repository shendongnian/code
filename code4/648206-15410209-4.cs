    var items = from n in registrosVipDosAños
                group n by new { n.Item, n.Description } into g
                select new {
                  Item = g.Key.Item,
                  Description = g.Key.Description,
                  Suma = g.Sum(x => x.Amount)
                };
    
    var topItems = items.OrderBy(x => x.Suma).Take(30);
