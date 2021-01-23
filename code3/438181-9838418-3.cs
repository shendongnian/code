    public class Flight
    {
        List<Person> passengers = new List<Person>();
        public IEnumerable<Person> Passengers
        {
            get { return passengers; }
        }
    }
