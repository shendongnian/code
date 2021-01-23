    var output = from item in op
                     join lstTp5 in lstTopFive on item.UnitOfOperations.Key equals lstTp5.SystemID
                     select new InformaticsBenchmarkSummary
                     {
                         CompanyId = item.CompanyId,
                         CompanyName = item.CompanyName,
                         LocationId = item.LocationId,
                         LocationName = item.LocationName,
                         UnitOfOperations = item.UnitOfOperations 
                     };
