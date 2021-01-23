    public abstract Airline
    {
      protected List<Flight> _flights = new List<Flight>();
      public abstract Flight AddFlight(string no, string time)
      {
        this._flights.add(new Flight(this, no, time));
      }
      public class Flight
      {
        protected Flight(Airline airline, string no, string time)
        {
        }
      }
    }
