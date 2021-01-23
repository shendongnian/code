    var query_join = (from e in ServiceContext.EventDeliverySet
                             join v in ServiceContext.VenueDeliverySet on e.Id equals v.EvendDeliveryId.Id
                             join vn in ServiceContext.VenueSet on v.Id equals vn.VenueDeliveryId.Id
                             join s in ServiceContext.SessionDeliverSet on e.Id equals s.EvendDeliveryId.Id
                             where e.EventDeliveryId.Value == id // *improtant (see below)
                             select new { EventDelivery = e, VenueDelivery = v, Venue = vn, SessionDeliver = s }).ToList();
