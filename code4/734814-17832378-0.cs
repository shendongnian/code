    var query = from r in table.AsEnumerable()
                group r by r.Field<string>("Task_Name") into g
                select new {
                   Task_Name = g.Key,
                   Hours = g.Sum(x => x.Field<int>("Hours"))
                };
