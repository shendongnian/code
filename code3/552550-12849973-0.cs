    // All of the beams which are strong enough
    var beamsForLoad = db.Values.Where(beam => beam.Ix >= iRequired);
    
    // All of the types of beam which are strong enough
    var elementTypesForLoad = beamsForLoad.Select(beam => beam.ElementType);
    
    var smallestBeamForTypes = elementTypesForLoad.Select(type => 
        new { 
            Type = type, 
            SmallestBeam = beamsForLoad.Where(beam => beam.ElementType == type)
                .Min(beam => beam.Ix) 
        });
