    class VehicleFactory<TVehicle> : IVehicleFactory
        where TVehicle:Vehicle
    {
        public virtual TVehicle ProduceVehicle()
        {
            throw new NotImplementedException();
        }
        
        // explicitly implement the interface by
        // returning the value of our actual method
        Vehicle IVehicleFactory.ProduceVehicle()
        {
            return ProduceVehicle();
        }
    }
