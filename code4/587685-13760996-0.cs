    var query = objects.GroupBy(o => o.Title)
                       .Select(g => new  
                       {
                           Title = g.Key,
                           Value = g.Select(x => x.Value).ToArray()
                       });
