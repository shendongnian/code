    class Airline
    {
        // code as it was
        public Flight AddFlight(string No, string Time)
        {
            var flight = new Flight(this, No, Time);
            AddFlight(flight);
            return flight;
        }
    }
