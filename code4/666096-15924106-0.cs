    public class FlightViewModel
    {
        private Flight _flight;
        public FlightViewModel(OutFlight outFlight)
        {
            FlightNumber = outFlight.FlightNumber;
            FlightType = FlightType.OutFlight;
           _flight = outFlight;
        }
        public FlightViewModel(InFlight inFlight)
        {
            FlightNumber = inFlight.FlightNumber;
            FlightType = FlightType.InFlight;
           _flight = inFlight;
        }
 
        public int FlightNumber 
        { 
           get { return _flight.FlightNumber; }
           set { _flight.FlightNumber = value; }
        }
        
        public FlightType FlightType { get; set; }
        ... other properties
    }
