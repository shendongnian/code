    List<int> systemIdTop5 = lstTopFive.Select(tp5 => tp5.SystemID).ToList();
    var objAct = (from item in op
                  select new InformaticsBenchmarkSummary
                  {
                      CompanyId = item.CompanyId,
                      CompanyName = item.CompanyName,
                      LocationId = item.LocationId,
                      LocationName = item.LocationName,
                      UnitOfOperations = systemIdTop5.Intersect(item.UnitOfOperations.Keys)
                                                     .ToDictionary(systemId => systemId, systemId => item.UnitOfOperations[systemId])
                  }).ToList();
