    using System.Collections.Generic;
    using System.Linq
    ...
    List<DateTime> dates = new List<DateTime>();
    dates.Add(new DateTime(2012, 04, 01));
    dates.Add(new DateTime(2012, 04, 05));
    dates.Add(new DateTime(2012, 04, 04));
    dates.Add(new DateTime(2012, 04, 02));
    dates.Add(new DateTime(2012, 04, 03));
    List<DateTime> orderedDates = dates.OrderBy(d => d);
