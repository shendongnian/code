    var accounts = _busDb.Session.QueryOver<QueueEntity>()
            .Select(
                Projections.SqlGroupProjection(
                    "SUBSTRING({alias}.Name, 1) as FirstChar", 
                    "SUBSTRING({alias}.Name, 1)",
                    new[] {"FirstChar"},
                    new[] {NHibernateUtil.String}),
                Projections.Count("id"));
