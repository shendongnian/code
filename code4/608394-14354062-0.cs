    public class FlightDetails
    {
       // ...
    }
    
    public class Passenger
    {
       // ...
    }
    
    public class Flight
    {
    	public FlightDetails { get; private set; }
        public List<Passenger> Passengers { get; private set; }
    
        public Flight(FlightDetails details)
        {
            FlightDetails = details;
            Passengers = new List<Passenger>();
        }
    
        public AddPassenger(Passenger p)
        {
            // check for ticket and so on..
            
            Passengers.Add(p);
        }
    }
