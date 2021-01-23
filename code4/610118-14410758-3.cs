    RegionType[] allRegionTypes = (RegionType[]) 
                                  Enum.GetValues(typeof(RegionType));
    	
    var validFlights = 
          GetPermutations<RegionType>(allRegionTypes, 2, true)
             .Select(perm => new 
                             { 
                               RegionType = perm.First(),
    	                       TravelRegionType = perm.Last() 
                             })
             .Where(result => result.RegionType == flight.RegionType &&  
                              result.TravelRegionType ==                            
                              flight.TravelRegionType)
             .Select(map => 
                       GetRegionTypeAndValueMapping(flight,
                         map.RegionType, 
                         map.TravelRegionType));
        // same fuctionality as my previous messy code
        // validates all flights selected by user
        // it doesn't matter if not all flights are valid
        // as long as one of them is
    	foreach(var validFlight in validFlights)
    	{
    		userSelectedRoutes.Any(kvp => IsRouteValid(flight.Directionality, 
    		                                           kvp.Key, 
    												   kvp.Value, 
    												   validFlight.First().Value,
    												   validFlight.Last().Value))
                                          .Dump("Any Flight");
    	}
