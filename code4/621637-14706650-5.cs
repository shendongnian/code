    var objAcu = (op.SelectMany(item => lstTopFive, (item, lstTp5) => new { item, lstTp5 })  // <- Bad readability
                    .Where(t => t.item.UnitOfOperations.ContainsKey(t.lstTp5.SystemID))
                    .Select(t =>
                            {
                                var objIbm = new InformaticsBenchmarkSummary
                                {
                                    CompanyId = t.item.CompanyId,
                                    CompanyName = t.item.CompanyName,
                                    LocationId = t.item.LocationId,
                                    LocationName = t.item.LocationName
                                };
                                objIbm.UnitOfOperations.Add(t.lstTp5.SystemID, t.item.UnitOfOperations[t.lstTp5.SystemID]);
                                return objIbm;
                            })).ToList();
