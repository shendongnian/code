    var result = from row in dt.AsEnumerable()
                 group row by new
                 {
                     c1 = r.Field<string>("col1"),
                     c2 = r.Field<string>("col2"),
                     c3 = r.Field<string>("col3")
                 } into section
                 select new
                 {
                     col1 = section.Key.c1,
                     col2 = section.Key.c2,
                     col3 = section.Key.c2,
                     col4 = section.Select(r => r.Field<string>("col4")).ToList()
                 };
