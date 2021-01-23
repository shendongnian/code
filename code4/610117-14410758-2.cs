    private bool IsRouteValid(Directionality direction, string origin, 
                              string destination, string departure, 
                              string arrival)
    {
        // both departure station and arrival station
        if (direction == Directionality.Between)
        {
    	    if(string.IsNullOrEmpty(departure))
    		{
    			return (destination.Equals(arrival,      
                        StringComparison.OrdinalIgnoreCase));
    		}
    		else if(string.IsNullOrEmpty(arrival))
    		{
    			return (origin.Equals(departure, 
                        StringComparison.OrdinalIgnoreCase));
    		}
    		else if(string.IsNullOrEmpty(departure) && 
                    string.IsNullOrEmpty(arrival))
    		{
    			return true;
    		}
    		else
    		{
                return (origin.Equals(departure,
                        StringComparison.OrdinalIgnoreCase) && 
                        destination.Equals(arrival, 
                        StringComparison.OrdinalIgnoreCase) || 
                        origin.Equals(arrival, 
                        StringComparison.OrdinalIgnoreCase) &&         
                        destination.Equals(departure,
                        StringComparison.OrdinalIgnoreCase));
    		}
        }
        else if (direction == Directionality.From)
        {
            return (origin.Equals(arrival, StringComparison.OrdinalIgnoreCase));
        }
        else if (direction == Directionality.To)
        {
            return (destination.Equals(departure, 
                   StringComparison.OrdinalIgnoreCase));
        }
    
        return false;
    }
