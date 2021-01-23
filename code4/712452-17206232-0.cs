    public abstract class Vehicle
    {
        public int SteeringWheelSize { get; private set; }
        ...
        protected Vehicle(int steeringWheelSize)
        {
            SteeringWheelSize = steeringWheelSize;
        }
    }
    public class Car : Vehicle
    {
        public Car() : base(20)
        {
        }
    }
    ...
