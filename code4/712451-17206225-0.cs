    public abstract class Vehicle
    {    
      public Transmission MyTransmission;
      public int NumberOfWheels;
      public int NumberOfSeats;
      public int Weight;
      public int TopSpeed; //etc.
    }
    
    public abstract class FourWheelVehicle : Vehicle
    {
      public int SteeringWheelSize;
    }
    
    public class Car : FourWheelVehicle
    {
        public Car()
        {
            SteeringWheelSize = 10;
        }
    }
    
    public class Truck : FourWheelVehicle
    {
        public Truck()
        {
            SteeringWheelSize = 20;
        }
    }
    
    
    public class FourWheelTransmission
    {
      public FourWheelVehicle ParentVehicle;
      public Transmission(FourWheelVehicle vehicle)
      {
        ParentVehicle = vehicle;
        //here, I want to access the SteeringWheelSize from its ParentVehicle object.
      }
    }
