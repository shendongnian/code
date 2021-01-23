    public struct Car
    {
        private readonly Maker _maker;
        private readonly Color _color;
        public static Car CarA = new Car(Maker.Ford, Color.Red);
        public static Car CarB = new Car(Maker.Bmw, Color.Black);
        public static Car CarC = new Car(Maker.Toyota, Color.White);
        private Car(Maker maker, Color color)
        {
            _maker = maker;
            _color = color;
        }
        public static bool operator ==(Car car1, Car car2)
        {
            return car1._maker == car2._maker && car1._color == car2._color;
        }
        public static bool operator !=(Car car1, Car car2)
        {
            return !(car1 == car2);
        }
    }
