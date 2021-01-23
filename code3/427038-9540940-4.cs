    public class Car
    {
        private const int DefaultGears = 5;
        private const int DefaultTopSpeed = 180;
        private readonly int gears;
        private readonly int topSpeed;
        public Car(int gears, int topSpeed)
        {
            this.gears = gears;
            this.topSpeed = topSpeed;
        }
        public static Car CreateWithGears(int gears)
        {
            return new Car(gears, DefaultTopSpeed);
        }
        public static Car CreateWithTopSpeed(int topSpeed)
        {
            return new Car(topSpeed, DefaultGears);
        }
    }
