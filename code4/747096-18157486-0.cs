    public class Vehicle
    {
        public virtual void Move()
        {
            Console.WriteLine("Vehicle Moving");
        }
    }
    public class Car : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Car Moving");
        }
    }
    public class RedCar : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Red car Moving");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var vehicles = new List<Vehicle>
                {
                    new RedCar(), new Car(),new Vehicle()
                };
            foreach (var vehicle in vehicles)
            {
                vehicle.Move();
            }
        }
    }
