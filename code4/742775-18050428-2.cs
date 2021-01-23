    var ids = new[] { 2, 9 };
    var results =
        from t in db.Tasks.Where(x => ids.Contains(x.ID))
        from bu in t.BuildingUsers
        from u in bu.Users.Where(x => x.ID != t.ID_USER)
        group u by new { u.ID, u.NAME } into g
        where t.BuildingUsers.Count() == db.Tasks.Count(x => ids.Contains(x.ID))
        select g.Key;
