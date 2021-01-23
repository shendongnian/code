    from c in orders  
    group c by c.name into g
      select new {
        Name = g.Key,
        Price = g.Where(c => (int)c.date.DayOfWeek == this._monday).Sum(c => c.Price)
      }
