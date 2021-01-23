    public class Car
    {
        public static Car[] AllCars { get; private set; }
        public Car()
        {
            // Class and constructor somewhat simplyfied.
            AllCars = new Car[4];
            for (int i = 0; i < 4; ++i) {
                AllCars[i] = new Novica();
            }
        }
    }
