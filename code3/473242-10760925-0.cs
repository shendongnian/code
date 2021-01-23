    var lastMeterReading = from meeters in metermodel.Meeters
                           join reading in metermodel.Readings on meeters.MeterNumber equals reading.MeterNumber
                           where (maalers.CustNo == 6085574)
                           orderby reading.Date descending
                           group meeters by new { meeters.MeterNumber, reading.Consumption, reading.Date } into result
                           from m in result.Take(3)
                           select new
                           {
                               Consumption = m.Consumption, No = m.MeterNumber, Date = m.Date
                           };
