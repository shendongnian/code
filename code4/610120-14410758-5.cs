    private List<KeyValuePair<RegionType, string>> 
                    GetRegionTypeAndValueMapping(Flight flight, 
                                                 RegionType regionType,
                                                 RegionType travelRegionType)
    {
    	var mapping = new List<KeyValuePair<RegionType, string>>();
    	if(regionType == RegionType.Station)
    	{
    		mapping.Add(new KeyValuePair<RegionType, string>
                              (RegionType.Station, flight.RegionCode));
    	}
    	else if(regionType == RegionType.Country)
    	{
    		mapping.Add(new KeyValuePair<RegionType, string>
                              (RegionType.Country, flight.RegionCountryCode));
    	}
    	else if(regionType == RegionType.All)
    	{
    		mapping.Add(new KeyValuePair<RegionType, string>
                              (RegionType.All, null));
    	}
    	
    	if(travelRegionType == RegionType.Station)
    	{
    		mapping.Add(new KeyValuePair<RegionType, string>
                              (RegionType.Station, flight.TravelRegionCode));
    	}
    	else if(travelRegionType == RegionType.Country)
    	{
    		mapping.Add(new KeyValuePair<RegionType, string>
                              (RegionType.Country, 
                               flight.TravelRegionCountryCode));
    	}
    	else if(travelRegionType == RegionType.All)
    	{
    		mapping.Add(new KeyValuePair<RegionType, string>
                              (RegionType.All, string.Empty));
    	}
    	
    	return mapping;
    }
