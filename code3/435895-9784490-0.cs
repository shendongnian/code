    //somewhere in the code have a method
    public static string GetVehicleName<T>(T vehicle)  where T : Vehicle, new()
    {
        return vehicle.GetVehicleName();
    }
    
    //abstract class Vehicle
    public abstract class Vehicle
    {
        public abstract string GetVehicleName ();
    }
    
    //Child class 
    public class Car : Vehicle
    {  
       public override string GetVehicleName()
       {
         return "Car";
       }
    }
