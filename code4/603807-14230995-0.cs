    var query = from row in table.AsEnumerable()
                group row by row.Field<string>("Day") into g
                let times = g.Select(r => 
                                    DateTime.ParseExact(r.Field<string>("SwipeTime"),
                                            "h:mm tt", CultureInfo.InvariantCulture))
                             .OrderBy(t => t.TimeOfDay)
                             .ToList()
                select new
                {
                    Date = g.Key,
                    TotalHours = (times.Last() - times.First()).TotalHours
                };
