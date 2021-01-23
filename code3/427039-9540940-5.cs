    public class Car
    {
        public const int DefaultGears = 5;
        public const int DefaultTopSpeed = 180;
        private readonly int gears;
        private readonly int topSpeed;
        public Car(int gears = DefaultGears, int topSpeed = DefaultTopSpeed)
        {
            this.gears = gears;
            this.topSpeed = topSpeed;
        }
    }
