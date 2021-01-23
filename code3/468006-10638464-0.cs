    public IQueryable<LocationStatusList> GetLocationStatus()
        {
            var status = (from a in ObjectContext.Locations
                            select new LocationStatusList
                            {
                                ID=a.ID,
                                Name=a.Name,
                                LastInspectionDate= ObjectContext.InspectionReadings.OrderByDescending(d => d.DateTaken).Select(e => e.DateTaken).FirstOrDefault()??DateTime.MinValue,
                                StatusNumber = ObjectContext.InspectionReadings.OrderByDescending(f => f.DateTaken).Select(g => g.Status).FirstOrDefault() ?? -1
                            });
            return status;
        }
