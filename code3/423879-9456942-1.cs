    public class Bat : Mammal, IFlier
    {
        private readonly IFlight _flight;
        public Bat(Flight flight)
        {
            _flight = flight;
        }
        public void Fly() // implements IFlier.Fly()
        {
            _flight.Fly();
        }
    }
