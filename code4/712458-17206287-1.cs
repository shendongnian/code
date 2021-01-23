    public abstract class Vehicle {    
      public Transmission MyTransmission  { get; set; }
      public int NumberOfWheels { get; set; }
      public int NumberOfSeats { get; set; }
      public int Weight { get; set; }
      public int TopSpeed { get; set; } //etc.
    }
    
    public interface ISteeringWheelVehicle {
    	int SteeringWheelSize { get; set; }
    }
    
    public class Car : Vehicle, ISteeringWheelVehicle {
    	public Car() {
    		SteeringWheelSize = 10;
    	}
    	
    	public int SteeringWheelSize { get; set; }
    }
    
    public class Truck : Vehicle, ISteeringWheelVehicle {
    	public Truck() {
    		SteeringWheelSize = 20;
    	}
    	
    	public int SteeringWheelSize { get; set; }
    }
    
    public class Bike : Vehicle {
    }
    
    public class FourWheelTransmission {
    	public Vehicle ParentVehicle;
    	public Transmission(Vehicle vehicle) {
    		ParentVehicle = vehicle;
    		
    		if (ParentVehicle is ISteeringWheelVehicle) {
    			var steeringWheelSize = ((ISteeringWheelVehicle)ParentVehicle).SteeringWheelSize;
    		}
    	}
    }
