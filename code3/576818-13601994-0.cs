    ICriteria criteria = Session.CreateCriteria<User>()
        .Add(Restrictions.Eq("Active", true))
        .CreateCriteria("Sites", "Site"); 
            .Add(Restrictions.In("Id", siteList.ToArray()))
            .Add(Restrictions.Eq("Active", true))
            .Add(Restrictions.Eq(access.ToString(), true))
    return criteria.List<User>();
