    namespace ConsoleApplication1
    {
        class Car
        {
        }
    
        class Truck: Car
        {
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Car[] cars = new[] { new Car(), new Truck() };
    
                foreach (Car machin in cars)
                {
                    Console.WriteLine("1 truck");
                }
    
                Console.Read();
            }
        }
    }
