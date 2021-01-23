        interface IVehicle {
        }
        class Car : IVehicle
        {
        }
        class Bicycle : IVehicle
        {
        }
        static void Main(string[] args)
        {
            var v1 = new Car();
            var v2 = new Bicycle();
            var list = new List<IVehicle>();
            list.Add(v1);
            list.Add(v2);
            foreach (var v in list)
            {
                Console.WriteLine(v.GetType());
            }
        }
