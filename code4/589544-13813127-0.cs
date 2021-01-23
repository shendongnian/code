    enum VehicleType
    {
        Passenger,
        Truck,
        // Etc...
    }
    public Interface IVehicle 
    {
        VehicleType Type { get; }
        ... // Properties Common to all vehicles
    }
   
    public sealed class Truck : IVehicle
    {
        // ... class stuff.
        // IVehicle implementation.
        public VehicleType Type { get { return VehicleType.Truck; } }
    }
