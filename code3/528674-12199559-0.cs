    public interface IVehicle {}
    public interface ICar : IVehicle {} //because pickup trucks share some car traits
    public interface IPickup : ICar, IVehicle {}
    public interface IStorage {}
    public class Car : ICar, IVehicle {}
    public class Pickup : IPickup, ICar, IVehicle {}
    public class ParkingLot : IStorage {}
    public class Hangar : IStorage {}
    public class Dealership
    {
      public static TVehicle GetVehicle<TVehicle>(IStorage storage)
        where TVehicle : IVehicle, new()
      {
        
      }
    }
    //now you can specialise if you really need to
   	public class CarDealership
	{
		public static Car GetVehicle(IStorage storage)
		{
			return Dealership.GetVehicle<Car>(storage);
		}
	}
	public class PickupDealership
	{
		public static Pickup GetVehicle(IStorage storage)
		{
			return Dealership.GetVehicle<Pickup>(storage);
		}
	}
