    from r in table.AsEnumerable()
    group r by new { 
         Category = r.Field<string>("Category"),
         Description = r.Field<string>("Description")
    } into g
    select new {
       Category = g.Key.Category,
       Description = g.Key.Description,
       CurrentHours = g.Sum(x => x.Field<int>("CurrentHours"),
       CTDHours = g.Sum(x => x.Field<int>("CurrentHours") + x.Field<int>("CTDHours"))
    } 
