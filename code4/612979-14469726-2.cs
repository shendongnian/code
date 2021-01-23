    class Car
    {
        // FROM Bike TO Car
        public static explicit operator Car(Bike bike)
        {
            return new Car();
        }
    }
