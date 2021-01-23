    select new 
        {
             Key = g.Key
             //....
        }).AsEnumerable()
    .Select(anon => new MeterReadingsForChart
           {
             ReadDate = new DateTime(anon.Key.Year, anon.Key.Month, 1),
             Value = anon.Value,
             Name = anon.Name
           });
