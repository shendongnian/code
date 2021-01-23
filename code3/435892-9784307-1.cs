    public class MyPlainVehicleCollection  //<Vehicle>  now Vehicle no longer is a Type Parameter
    {
         private List<Vehicle> listofVehicles = new List<Vehicle>();   // uses class Vehicle
    
         public void AddVehicle(Vehicle v) { listofVehicles.Add(v); }
    }
