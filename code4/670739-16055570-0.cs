    ICriteria criteria = NHibernateSession.CreateCriteria(persitentType);  
    criteria.Add(Restrictions.Or (
        Restrictions.Eq ("StatusFile", 10), 
        Restrictions.IsNull ("StatusFile)
    ));
