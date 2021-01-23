    public class Car
    {
    }
        
    public class Race
    {
        private IList<Car> Cars { get; set; }
    }
        
    public class Ticket
    {
        private IList<Race> Races { get; set; }
    }
