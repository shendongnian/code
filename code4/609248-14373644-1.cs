    public class CarContainer
    {
        public Car car;
        public CarContainer(Car c)
        {
            this.car = c;
            Console.WriteLine("\nCreated container for {0}", this.car.Name);
        }
        public void Brake()
        {
            this.car.Velocity--;
            Console.WriteLine("Braked {0} to velocity {1} (with containment)",
                this.car.Name, this.car.Velocity);
        }
    }
