    data.GroupBy(d => new { d.Id, d.Name, d.Category })
        .Select(g => new
                     {
                         Id = g.Key.Id,
                         Value = g.Sum(s => s.Value),
                         Name = g.Key.Name,
                         Category = g.Key.Category
                     })
