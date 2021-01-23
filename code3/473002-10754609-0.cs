        abstract class Vehicle {
            public int NumberOfWheels { get; set; }
        }
        class Car : Vehicle
        {
            public Car()
            {
                NumberOfWheels = 4;
            }
        }
        class Bicycle : Vehicle
        {
            public Bicycle()
            {
                NumberOfWheels = 2;
            }
        }
        static void Main(string[] args)
        {
            var v1 = new Car();
            var v2 = new Bicycle();
            var list = new List<Vehicle>();
            list.Add(v1);
            list.Add(v2);
            foreach (var v in list)
            {
                Console.WriteLine(v.NumberOfWheels);
            }
            Console.ReadKey();
        }
