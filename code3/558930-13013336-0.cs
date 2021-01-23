    var v1 = dc.vehicle.Where(v => v.vehicleID == param.vehicleID)
        .Select(v => new {
                            Id = v.vehicleID,
                            Cars = v.Cars.Where(c => c.Type == "Petrol"),
                            Buses = v.Buses.Where(c => c.Type == "Petrol")
                         }).First();
