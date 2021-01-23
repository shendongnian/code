    var query = from row in table.AsEnumerable()
                group row by row.Field<string>("Day") into g
                let times = g.Select(r => DateTime.Parse(r.Field<string>("SwipeTime")))
                             .OrderBy(t => t.TimeOfDay)
                             .ToList()
                select new
                {
                    DateTime.Parse(g.Key).Date,
                    (times.Last() - times.First()).TotalHours
                };
