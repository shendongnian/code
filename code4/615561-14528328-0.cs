    var list = session
      .CreateCriteria<Customer>()
      .SetProjection
      (
           Projections.SqlProjection
           (   
              "fCompanyID, ROW_NUMBER() over( PARTITION BY fCompanyID order by fPropertyID) as RowNumber"
              , new string[] {"fCompanyID", "RowNumber"}
              , new IType[] { NHibernate.NHibernateUtil.Int32, NHibernate.NHibernateUtil.Int32}
           )
      )
      .SetResultTransformer(Transformers.AliasToBean<ResultDTO>())
      .List<ResultDTO>()
    ;
