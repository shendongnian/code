    var list = session
      .CreateCriteria<MyEntity>() // mapped to 'myTable' table 
      .SetProjection
      (
           Projections.SqlProjection
           (        
              "Code, Name, row_number() over (partition by questionaireId order by stepnumber desc) as rid"
              , new string[] {"Code", "Name"}
              , new IType[] { NHibernate.NHibernateUtil.String
                         , NHibernate.NHibernateUtil.String }
           )
      )
      .SetMaxResults(1)  // this is something like t.rid = 1
      .SetResultTransformer(Transformers.AliasToBean<MyEntity>())
      .List<MyEntity>()
    ;
