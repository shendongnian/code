    public IQueryable<Excursion> GetExcustions(IList<int> excursionIds) 
    {
        var query = clsApplication._oDBConnection.tblGuideExcursions;
        foreach(var id in excursionIds)
        {
            query = query.Where(x=>x.ExcursionId == id);
        }
        return query;
    }
