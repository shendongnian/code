    var data = srv.GetTSMMetricData(Mode, Territories, selectedTerritory)
               .GroupBy(x => x.ItemNumber)
               .Select( x => new
                            {
                                ItemNumber = x.Key,
                                Count = x.Count()
                            } )
               .OrderByDescending(x => x.Count)
               .ToList();
    
