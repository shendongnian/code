    var ids = new[] { 2, 9 };
    var results =
        from t in db.Tasks
        join bu in db.BuildingUsers on t.ID_BUILDING equals bu.ID_BUILDING
        group bu by bu.ID_BUILDING into bg
        join u in db.Users on bg.Key equals u.ID
        where ids.Contains(t.ID) && u.ID != t.ID_USER
        group u by new { u.ID, u.NAME } into g
        where bg.Count() == db.Tasks.Count(t2 => ids.Contains(t2.ID))
        select g.Key;
