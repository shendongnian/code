    meters.Where(mt=>desiredMeters.Contains(mt)).Select(mt=>
       new{
         mt.Id,
         First = mt.Readings.Where(<is in period>).OrderBy(rd=>rd.Time).FirstOrDefault(),
         Last = mt.Readings.Where(<is in period>).OrderBy(rd=>rd.Time).LastOrDefault()
       });
