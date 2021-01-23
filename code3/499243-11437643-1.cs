    public abstract class Airline
    {
      protected List<Flight> _flights = new List<Flight>();
      public abstract Flight AddFlight(string no, string time)
      {
        this._flights.Add(new Flight(this, no, time));
      }
      public class Flight
      {
        protected Flight(Airline airline, string no, string time)
        {
        }
      }
    }
