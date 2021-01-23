    public IQueryable<LocationStatusList> GetLocationStatus()
        {
            var status = (from a in ObjectContext.Locations
                          select new LocationStatusList
                            {
                                ID=a.ID,
                                Name=a.Name,
                                LastInspectionDate= (from b in ObjectContext.Inspections
                                                     from c in ObjectContext.InspectionReadings
                                                     where c.InspectionItemID==b.ID && b.LocationID==a.ID
                                                     orderby c.DateTaken descending
                                                     select c.DateTaken).FirstOrDefault()??DateTime.MinValue,
                                
                                
                                StatusNumber =  (from b in ObjectContext.Inspections
                                                 from c in ObjectContext.InspectionReadings
                                                 where c.InspectionItemID==b.ID && b.LocationID==a.ID
                                                 orderby c.DateTaken descending
                                                 select c.Status).FirstOrDefault()??-1,
                            });
            return status;
        }
