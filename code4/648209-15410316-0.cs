    var filtroprimeros30 =  registrosVipDosAnos
                            .GroupBy(m => new {m.Item, m.Description})
                            .Select(g => new {
                               Item = g.Key.Item,
                               Description = g.Key.Description,
                               Suma = g.Sum(n => n.Amount)
                            })
                            .OrderBy(x => x.Suma)
                            .Take(30);
