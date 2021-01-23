    var output = from item in op
                 from lstTp5 in lstTopFive
                 where item.UnitOfOperations.ContainsKey(lstTp5.SystemID)
                 select new InformaticsBenchmarkSummary()
                 {
                     CompanyId = item.CompanyId,
                     CompanyName = item.CompanyName,
                     LocationId = item.LocationId,
                     LocationName = item.LocationName,
                     UnitOfOperations =
                     {
                         { lstTp5.SystemID, item.UnitOfOperations[lstTp5.SystemID] }
                     }
                 };
