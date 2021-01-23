    class Program
    {
        static void Main(string[] args)
        {
            Wheel wheel = new Wheel();
            Croupier croupier = new Croupier(wheel);
            croupier.SpinWheel();
        }
    }
    class Wheel
    {
        public void Spin()
        {
            Console.WriteLine("Wheel Spun");
        }
    }
    class Croupier
    {
        private Wheel wheel;
        public Croupier(Wheel wheel)
        {
            this.wheel = wheel;
        }
        public void SpinWheel()
        {
            wheel.Spin();
        }
    }
