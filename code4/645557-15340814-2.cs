    db.Zeiterfassung
      .Select(z => new { z.Zeit, z.Taetigkeit.Taetigkeit1, z.Firma.Name })
      .GroupBy(x => new { x.Taetigkeit1, x.Name })
      .Select(g => new Evaluation {
           companyName = g.Key.Name,
           skillName = g.Key.Taetigkeit1, 
           time = g.Sum(y => y.Zeit)
      });
