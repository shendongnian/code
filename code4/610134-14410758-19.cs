    	foreach(var route in userSelectedRoutes)
    	{
    		foreach(var validFlight in validFlights)
    		{
    			bool condition = IsRouteValid(flight.Directionality, 
                                              route.Key, 
                                              route.Value, 
                                              validFlight.First().Value, 
                                              validFlight.Last().Value);
    	 		Console.WriteLine(string.Format("{0}-{1} {2}", 
                                                   route.Key,     
                                                   route.Value, 
                                                   condition.ToString()));
    		}
    	}
