    class Bike
    {
        public static explicit operator Bike(Car car)
        {
            return new Bike();
        }
    }
