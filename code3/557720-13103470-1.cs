    IList<Trazabilidad> result = session.CreateCriteria(typeof(Trazabilidad), "TZ")
     .CreateAlias("CodigoPuesto1", "CP1")
     .CreateAlias("CodigoPuesto2", "CP2", JoinType.None, 
         Restrictions.Disjunction()
            .Add(Restrictions.EqProperty("TZ.Codigo1", "CP.Id"))
           .Add(Restrictions.EqProperty("TZ.Codigo2", "CP.Id"))
     )
     .Add(Expression.Disjunction() //esto es un OR
         .Add(Restrictions.Eq("P1.ConfigLinea", cl))
         .Add(Restrictions.Eq("P2.ConfigLinea", cl))
     )
     .List<Trazabilidad>()
