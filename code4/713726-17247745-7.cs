    var criteria = 
        session.QueryOver<Entity>()
        .JoinQueryOver<IDictionary<string, EntityLocale>>(c => c.Locales)
        .UnderlyingCriteria;
    
    var list = criteria
        .Add(Restrictions.Eq("CultureName", "en"))
        .SetProjection(Projections.SqlProjection("Name"
            , new string[] { "name" }
            , new IType[] { NHibernateUtil.String }))
        .List()
        .Cast<string>()
        .ToList<String>();
