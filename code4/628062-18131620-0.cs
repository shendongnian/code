    public IList<DealerInfo> GetBusinessLocations(Guid? locationId)
             {
            using (var db = new DealerContext())
                 {
                var query = db.DealerDetails
                    .Join(db.DealerValidations,
                        d=>new {bizId=d.BusinessId,lId=d.LocationId},
                        dv=>new {bizId=dv.BusinessID,lId= dv.LocationID},
                        (d,dv)=>d);
                if (locationId.HasValue)
                    query = query.Where(d => d.LocationId == locationId.Value);
                return GetDealerDetails(query)
                    .OrderBy(d =>d.DealerName)
                    .ToList();
            }
        }
