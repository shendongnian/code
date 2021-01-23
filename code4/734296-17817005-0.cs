    var B = A.GroupBy(x => new { x.Name, x.EngineType })
             .Select(g => new Car
             {
                 Name = g.Key.Name,
                 EngineType = g.Key.EngineType,
                 Months = g.SelectMany(x => x.Months.Select((y,i) => new { i, y = int.Parse(y) }))
                           .GroupBy(x => x.i)
                           .OrderBy(g2 => g2.Key)
                           .Select(g2 => g2.Sum(x => x.y).ToString()).ToList()
             }).ToList();
