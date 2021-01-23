    var query = from r in records
                group r by new { r.Id, r.StartDate.Date } into g
                select new {
                   g.Key.Id,
                   g.Key.Date,
                   TotalDuration = g.Sum(x => (x.EndDate - x.StartDate).TotalMinutes)
                };
