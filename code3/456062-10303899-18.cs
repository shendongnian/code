    NHibernate.ISession ss = GetSessionFromSomeWhere();
    
    NHibernate.ICriteria crt = ss.CreateCriteria<MasterEnt>();
    crt
        .Add(NHibernate.Criterion.Expression.IdEq(17))
        //here is "force eager load at runtime"
        .SetFetchMode("DetailEntList", NHibernate.FetchMode.Join);
    MasterEnt mEnt = crt.UniqueResult<MasterEnt>();
