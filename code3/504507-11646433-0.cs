    foreach (var row in rows)
    {
        using (var session = SessionFactory.OpenSession())
        using (var tx = session.BeginTransaction())
        {
             var whatever = ...
             session.Save(whatever);
             tx.Commit();
        }
    }
