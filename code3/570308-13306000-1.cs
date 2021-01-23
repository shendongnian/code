    var customerReadings = (from m in entity.MeterReadings
        join n in entity.MeterReadingDetails on m.sno equals n.ReadingId
        where m.Meters.CustomerId == CustomerId && m.ReadDate >= StartDate && m.ReadDate <= EndDate && m.Meters.TypeId == MeterTypeId
        group n by new { Year = m.ReadDate.Value.Year, Month = m.ReadDate.Value.Month} into g
        select new
        {
             Key = g.Key,
             Value = g.Sum(x => x.Value),
             Name = g.FirstOrDefault().MeterReadingTypes.TypeName
         }).AsEnumerable()
           .Select(anon => new MeterReadingsForChart
           {
             ReadDate = new DateTime(anon.Key.Year, anon.Key.Month, 1),
             Value = anon.Value,
             Name = anon.Name
           });
