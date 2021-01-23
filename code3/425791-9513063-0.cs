       int maxResults = 300;  // Default value.
       var criteria = DetachedCriteria.For<ConeSlab>()
           .CreateAlias("Cone", "C")
           .CreateAlias("Slab.SlabPDO", "SP")
           .Add(Restrictions.Eq("C.Mill", codigoLaminador))
           .Add(Restrictions.IsNotNull("C.IdentBeginDtm"))
           .Add(Restrictions.IsNotNull("SP.IdentBeginDtm"));
        Junction disjunction = Restrictions.Disjunction(); 
        //Identificadas
        if (placasAEnfornar > 0)
        {
            ICriterion criterion = Restrictions.Conjunction()
                .Add(Restrictions.IsNotNull("SP.IdentEndDtm"))
                .Add(Restrictions.IsNull("SP.ChargeDtm"))
                .Add(Restrictions.IsNull("SP.RejectDtm"));
            disjunction.Add(criterion);
            maxResults = 10; 
        }
        //Enfornadas
        if (placasEnfornadas)
        {
            ICriterion criterion = Restrictions.Conjunction()
                .Add(Restrictions.IsNotNull("SP.ChargeDtm"))
                .Add(Restrictions.IsNull("SP.DischDtm"))
                .Add(Restrictions.IsNull("SP.RejectDtm"));
            disjunction.Add(criterion); 
            maxResults = 20;
        }
        //Desenfornadas
        if (placasDesenfornadas > 0)
        {
            ICriterion criterion = Restrictions.Conjunction()
                .Add(Restrictions.IsNotNull("SP.DischDtm"))
                .Add(Restrictions.IsNull("SP.MillDtm"))
                .Add(Restrictions.IsNull("SP.RejectDtm"));
            disjunction.Add(criterion); 
            maxResults = 50; 
       }
        criteria.Add(disjunction);
        criteria.SetMaxResults(maxResults);
