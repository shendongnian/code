    public static class VehicleFactory
    {
        public static Vehicle CreateVehicle(...)
        {
            // conditional stuff that decides what kind of vehicle to construct
            if (...) 
            {
                return new Bicycle(...);
            }
            else if (...) 
            {
                return new Car(...);
            }
            else
            {
                throw new UnsupportedVehicleException();
            }
        }
    }
