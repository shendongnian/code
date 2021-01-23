    public class VehicleContainer{
       public List<IVehicle> Vehicles { get; private set; }
       ...
    }
    ....
    VehicleContainer vc = new VehicleContainer();
    vc.Vehicles  = new List<IVehicle>() // this is an error, because of the private set
    int x = vc.Vehicles.Count; // this is legal, property access
    vc.Vehicles.Add(new Vehicle()); //this is legal, method call
