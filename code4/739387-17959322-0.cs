    from b in db.Buildings
    join u in db.BuildingUsers on b.ID equals u.ID_BUILDING into g
    orderby g.Count(), b.Name descending
    select new 
    {
        Id = b.ID,
        Name = b.NAME,
        Total = g.Count()
    }
