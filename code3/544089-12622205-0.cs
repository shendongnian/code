    public IQueryable<BusinessUnit> GetBusinessUnits()
    {
        var includedBU = from cat in ObjectContext.CabSystemsModelCategories
                                                            group cat by cat.BUID into grouping
                                                            select grouping.Key;
        return ObjectContext.BusinessUnits.Include("CabSystemsModelCategories").
                Where((w) => includedBU.Contains(w.ID)).
                OrderBy((o) => o.ID);
    }
