    query.Add(Restrictions.InsensitiveLike(Projections.Property<Order>(a => a.OrderId1), OrderId2, MatchMode.Anywhere))
    .Add(Restrictions.InsensitiveLike(Projections.Property<Order>(a => a.OrderId2), OrderId1, MatchMode.Anywhere));
    // ... or ...
    query.Add(
        Restrictions.Or(
            Restrictions.InsensitiveLike(Projections.Property<Order>(a => a.OrderId1), OrderId2, MatchMode.Anywhere,
            Restrictions.InsensitiveLike(Projections.Property<Order>(a => a.OrderId2), OrderId1, MatchMode.Anywhere
        )
    );
