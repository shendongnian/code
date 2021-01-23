    private bool IsRouteValid(Directionality direction, string origin, 
                              string destination, string departure, 
                              string arrival)
    {
         // ** == All stations/countries
         if ((origin == null && departure == "**") &&
             (destination == null && arrival == "**"))
         {
             return true;
         }
         else if (origin == null && departure == "**")
         {
            return destination.Equals(arrival, StringComparison.OrdinalIgnoreCase);
         }
         else if (destination == null && arrival == "**")
         { 
           return origin.Equals(departure, StringComparison.OrdinalIgnoreCase);
         }
        // both departure station and arrival station
        if (direction == Directionality.Between)
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
