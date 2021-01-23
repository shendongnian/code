    var groupQuery = from r in Foundrows.AsEnumerable()
                     let time = TimeSpan.Parse(r.Field<string>("CallTime"))
                     group r by time.Hours into g
                     select new {
                        Hrs = g.Key,
                        CallCount = g.Count()
                     };
---
    Foundrows.AsEnumerable()
             .Select(r => {
                 TimeSpan time;
                 return new {
                    Row = r,
                    Time = TimeSpan.TryParse(r.Field<string>("CallTime"), out time) ?
                           time : (TimeSpan?)null
                 };
             })
             .Where(x => x.Time.HasValue)
             .GroupBy(x => x.Time.Value.Hours)
             .Select(g => new {
                 Hrs = g.Key,
                 CallCount = g.Count()
             });
