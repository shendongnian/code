    public interface ISteerable
    {
        int SteeringWheelSize { get; }
    }
    public abstract class Vehicle
    {
        // Properties here
    }
    public class Car : Vehicle, ISteerable
    {
        public SteeringWheelSize { get { return 20; } }
    }
    ...
    public class FourWheelTransmission
    {
        // We know we can safely cast this to ISteerable
        private Vehicle vehicle;
        private FourWheelTransmission(Vehicle vehicle)
        {
            this.vehicle = vehicle;
        }
        public static FourWheelTransmission<T> FromSteerableVehicle(T vehicle)
            where T : Vehicle, ISteerable
        {
        }
    }
