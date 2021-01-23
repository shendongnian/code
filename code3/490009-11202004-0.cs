    interface IWheel
	{
	}
	
	class CarWheel : IWheel
	{
	}
	
	interface IVehicleBase<T> 
	{
	}
	
	class Car : IVehicleBase<CarWheel>
	{
	}
	
	class VehicleFactory
	{
		public static IVehicleBase<T> GetNew<T>() 
		{
			if (typeof(T) == typeof(CarWheel))
			{
				return (IVehicleBase<T>)new Car();
			}
			else
			{
				throw new NotSupportedException();
			}
		}
	}
