    var ids = new[] { 2, 9 };
    var results =
        from t in db.Tasks
        join bu in db.BuildingUser on t.ID_BUILDING equals bu.ID_BUILDING
        join u in User on bu.ID_USER equals u.ID
        where ids.Contains(t.ID) && u.ID != t.ID_USER
        group u by new { u.ID, u.NAME } into g
        where COUNT(bu.ID_BUILDING) == db.Tasks.Count(t2 => ids.Contains(t2.ID))
        select g.Key;
