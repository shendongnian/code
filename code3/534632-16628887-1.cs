    var query_join = (from e in ServiceContext.EventDeliverySet
                             join v in ServiceContext.VenueDeliverySet on e.EventDeliveryId equals v.EvendDeliveryId.Id
                             join vn in ServiceContext.VenueSet on v.VenueDeliveryId equals vn.VenueDeliveryId.Id
                             join s in ServiceContext.SessionDeliverSet on e.EventDeliveryId equals s.EvendDeliveryId.Id
                             where e.EventDeliveryId == id // *improtant (see below)
                             select new { EventDelivery = e, VenueDelivery = v, Venue = vn, SessionDeliver = s }).ToList();
