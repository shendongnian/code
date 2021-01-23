    public class Passenger
    {
        public Passenger(string name, int passportNumber)
        {
            PassengerName = name;
            PassportNumber = passportNumber
        }
        public string PassengerName { get; set; }
        public int PassportNumber { get; set; }
    }
    public class FlightDetails
    {
        public FlightDetails(int flightNumber, string flightDestination, string planmodel)
        {
            FlightNumber = flightNumber;
            FlightDestination = flightDestination;
            PlanModel = planmodel;
            Passengers = new List<Passengers>();
        }
        public int FlightNumber { get; set; }
        public string FlightDestination  { get; set; }
        public string PlanModel { get; set; }
        public List<Passenger> Passengers { get; set; }
            public void AddPassenger(string name)
        {
            int MAX_PASSENGRS=2;
            int passengersNumber = Passengers.Count();
            if (passengersNumber<MAX_PASSENGRS)
            {
                var passengersList = new List<Passenger>();
                passengersList.Add(name);//// error here, why?
            }
        }
    public static void Main(string[] args)
    {
        var flightList = new List<FlightDetails>();
        var passengersList = new List<Passenger>();
        //Add passenger-objects to passengers-list
        
        var flightOne = new FlightDetails(12, "France", "Jumbo");
        flightOne.Passengers = passengersList;
        flightList.Add(a);
    }
