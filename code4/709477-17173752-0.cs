    public IQueryable<Inspections> 
    GetLatestInspectionDatesForAllRestaurants(int numRecords)
    {
         var subQuery =  _session.Query<Inspections>()
         .OrderByDescending(x => x.InspectionDate);
    
         var inspections = _session.Query<Inspections>()
                            .Where(x => subQuery.Where(y => y.InspectionDate == 
                                   x.InspectionDate).Take(numRecords).Contains(x))
                            .OrderBy(x => x.WellDataId);
        return inspections;
    }
