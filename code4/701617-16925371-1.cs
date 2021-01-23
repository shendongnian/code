    //define the query that returns allowed VehicleAttributes
    allowedAttributesQuery =from ua in context.UserAttributes
                              where ua.UserId == UserSession.CurrentUser.UserId
                              select ua.VehicleAttribute;  //I suppose that VehicleAttribute navigation property exists in the UserAttribute 
    //query that joins Vehicles with the allowedAttributes subquery
    var vehicle = (from v in context.Vehicles
                               join va in allowedAttributesQuery on v.VehicleId equals va.VehicleId into vAttributes
                               from vehicleAttributes in vAttributes.DefaultIfEmpty()
                               where v.VehicleId == vehicleId
                               select new { v, vehicleAttributes });
