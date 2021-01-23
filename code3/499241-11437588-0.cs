        public Flight(Airline Airline, string No, string Time)
        {
            this.No = No;
            this.Time = Time;
            this.Airline = Airline;
            Airline.AddFlight(this);
        }
?
