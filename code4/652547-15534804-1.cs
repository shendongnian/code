    class Plane
    {
        List<Passenger> lPassengers = null;
        public Plane()
        {
    
        }
    
        public List<Passenger> Passengers
        {
            get
            {
                if (this.lPassengers == null)
                    this.lPassengers = new List<Passenger>();
    
                return this.lPassengers;
            }
            set { this.lPassengers = value; }
        }
    }
