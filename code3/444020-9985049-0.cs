    var result = ents.T1
        .Where(x => x.Id == 17 || x.Id == 18)
        .GroupBy(x => new 
                     { 
                        Id2 = x.T2.Id, 
                        Id3 = x.T3.Id,
                        ...
                        // etc group fields 
                     })
        .Select(x => new
                     { 
                        Importe = x.Sum(i=>i.Importe)
                        x.Key.Id2,
                        // other group fields
                        ...
                     })
        .ToArray();
