    public IQueryable<Inspections> 
      GetLatestInspectionDatesForAllRestaurants(int numRecords)
    {
    
      IQueryable<Inspections> inspections= _session.Query<Inspections>()
                            .GroupBy(r=> r.RestaurauntName)
                            .SelectMany(g => g
                                            .OrderByDescending(r => r.InspectionDate)
                                            .Take(numRecords));
    
      return inspections.ToList().AsQueryable();
    }
