    var grouped = sites.OrderBy(x => x.Type)
                       .GroupBy(x => x.Type)
                       .Select(g => new { Type = g.Key,
                                          Sites = g.Select(site => new {
                                                               site.Title,
                                                               site.URL
                                                           } });
