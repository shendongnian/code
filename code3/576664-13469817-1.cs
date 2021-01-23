    var ev = events.Select(d => new { Month = d.Month, Date = d })
                    .Where(d => (d.Date >= DateTime.Now || (d.Date.Day == DateTime.Now.Day && d.Date.Month >= DateTime.Now.Month)))
                    .OrderBy(d => d.Date)
                    .Select(d => new { Month = d.Month })
                    .Distinct();
