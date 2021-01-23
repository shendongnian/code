    var filtroprimeros30 = 
         (from nuevo in registrosVipDosAños
          group nuevo by new { nuevo.Item, nuevo.Description } into g  // here    
          select new {
              g.Key.Item,
              g.Key.Description,
              Suma = g.Sum(n => n.Amount)
          })
         .OrderBy(x => x.Suma)
         .Take(30);
