    list.GroupBy(x => x.Name)
        .Select(g => new {
              Name = g.Key,
              Elements = g.GroupBy(x => x.Layer)
                          .Select(g => g.Sum(z => z.Value))
           });
