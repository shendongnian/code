    public class MyPlainVehicleCollection  //<Vehicle>  no Type Parameter
    {
         private List<Vehicle> listofVehicles = 
                 new List<Vehicle>();  // class Vehicle
    
         public void AddVehicle(Vehicle v) { listofVehicles.Add(v); }
    }
