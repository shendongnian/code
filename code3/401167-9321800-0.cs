    public class Car
    {
        public static Car Instance { get; private set; }
        static Car() { Car.Instance = new Car(); }
        private Car() { }
        public static class Door
        {
            public static void Close()
            {
                /* do something with Car.Instance */
            } 
        }
    }
