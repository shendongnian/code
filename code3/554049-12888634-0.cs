    namespace Generic_cars
    {
     class VehicleLot
     {
        public List<Vehicle> Lot = new List<Vehicle>();
    
        IEnumerable<Vehicle> Vehicles
        {
            return Lot;
        }
     }
    }
