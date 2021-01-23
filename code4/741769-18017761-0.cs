    // define query, but don't execute it
    var query = cdrContext.Mytable.Where(c => c.FacilityID == facilityID && 
                                              c.FilePath != null && 
                                              c.TimeStationOffHook < oldDate)
                                  .OrderBy(c => c.TimeStationOffHook)
                                  .Take(pageSize);
    
    List<Foo> itemsToUpdate = query.ToList(); // get first N items
    
    while(itemsToUpdate.Any()) // all items updated
    {
        // update items
        cdrContext.SaveChanges();
        itemsToUpdate = query.ToList(); // get first N items
    }
