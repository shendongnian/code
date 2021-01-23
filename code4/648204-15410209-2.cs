    var items = from nuevo in registrosVipDosAños
                group nuevo by new { nuevo.Item, nuevo.Description } into g
                select new {
                  Item = g.Key.Item,
                  Description = g.Key.Description,
                  Suma = g.Sum(n => n.Amount)
                };
    
    var topItems = items.OrderBy(x => x.Suma).Take(30);
