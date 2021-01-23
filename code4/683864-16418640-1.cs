    public class Car
    {
    }
        
    public class Race
    {
        public IList<Car> Cars { get; set; }
    }
        
    public class Ticket
    {
        public IList<Race> Races { get; set; }
    }
