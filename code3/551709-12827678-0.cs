    var query = from t1 in Repo.GetThing1()
                join t2 in Repo.GetThing2() on t1.Key equals t2.Key
                select new { Existing = t1, NewValue = t2.SomeField };
    var list = query.ToList();
    foreach (var pair in list)
    {
        pair.Existing.SomeField = pair.NewValue;
    }
