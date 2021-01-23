     var results = Data.GroupBy(l => l.Name);
                .SelectMany( g => 
                             new 
                             { 
                                 Metadata = g.Key, 
                                 data = g 
                             });
    var pivoted = new List<PivotedEntity>();
    
    foreach(var item in results)
    {
        pivoted.Add( 
            new PivotedEntity
            {
                Id  = item.Id,
                Model = item.data.Where(x => x.Name == "Model")
                            .FirstOrDefault().value,
                Manufacturer = item.data.Where(x => x.Name == "Manufacturer")
                             .FirstOrDefault().value,
            });
    }
