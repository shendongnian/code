    public Interface IVehicle 
    {
        ... //Properties Common to all vehicles
    }
    
    public class Car : IVehicle
    {
        ... //Properties to implement IVehicle
        ... //Properties specific to Car
    }
    public class Vehicles
    {
        public IVehicle Vehicle { get; set; }
    }
    
    var vehicles = new Vehicles();
    vehicles.Vehicle = new Car();
    ... //Do whatever else you need to do.
