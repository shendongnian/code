     var query = orders.AsEnumerable()   
                  .GroupBy(t => new {CountryCode= t.Field<string>("CountryCode"),
                                     CustomerName=t.Field<string>"CustomerName"),
                               (key, group)=> new {CountryCode = key.CountryCode,CustomerName=key.CustomerName})
    .Select(t => new {t.CountryCode, t.CustomerName}); 
