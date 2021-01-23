    var query = from r in table.AsEnumerable()
                group r by new { 
                   Name = r.Field<string>("Name"),
                   Value = r.Field<string>("Value")
                } into g
                select new {
                    g.Key.Name,
                    g.Key.Value,
                    Count = g.Count()
                };
