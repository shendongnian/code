    public class FlightDetails
    {
        public FlightDetails(int flightNumber, string flightDestination, string planmodel)
            : this(flightNumber, flightDestination, planmodel, new List<Passenger>())
        {
        }
        public FlightDetails(int flightNumber, string flightDestination, string planmodel, List<Passenger> passengers)
        {
            FlightNumber = flightNumber;
            FlightDestination = flightDestination;
            PlanModel = planmodel;
            
            if(passengers.Count > 2)
                //throw exception or error
            else
                _passengers = passengers;
        }
        private List<Passenger> _passengers = new List<Passenger>();
        public int FlightNumber { get; set; }
        public string FlightDestination  { get; set; }
        public string PlanModel { get; set; }
        public IEnumerable<Passenger> Passengers { get { return _passengers; } }
       
        public void AddPassenger(string name, int number)
        {
            int max = 2;
            int passengersNumber = _passengers.Count;
            if (passengersNumber < max)
            {
                _passengers.Add(new Passenger(name, number);
            }
        }
    }
