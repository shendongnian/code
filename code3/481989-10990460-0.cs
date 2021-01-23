    var allDates = from idx in Enumerable.Range(0, (currentDate - lastDate).Days)
                   select lastDate.AddDays(idx);
    summary = (
              from allDate in allDates
              join su in summary on allDate.Day equals su.DateString into x
              from su in x.DefaultIfEmpty()
              select new OpensOverTimeViewModel
              {
                  DateString = allDate.Day,
                  TotalOpens = su == null ? 0 : su.TotalOpens,
                  ElementName = ""
              }).ToList();
