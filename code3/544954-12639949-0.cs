    var lookupValues = vehicles
                
                    .OrderBy(a => a.DateRegistered) 
                    .Select(vehicle =>
                    new LookupValue()
                    {
                        Id = vehicle.Id,
                        Description = vehicle.RegistrationNumber + " " +vehicle.DateRegistered.ToString("dd/mm/yyyy"),
                        Data = Json.GetString(vehicle),
                        Active = true
                    });
            return lookupValues;
