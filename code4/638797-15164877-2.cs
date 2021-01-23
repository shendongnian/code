    using System;
    namespace ConsoleApplication1
    {
        public class Car
        {
            public double number { get; set; }
            public Car()
            {
                Random r = new Random();            
                number = r.NextDouble();// NextDouble isn't static and requires an instance
            }
        }
        public class Factory
        {
            public Car[] arr;
            public Factory(int num)
            {
                arr = new Car[num]; 
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Factory f = new Factory(3);
                f.arr[0] = new Car();
                f.arr[1] = new Car();
                f.arr[2] = new Car();
                foreach (Car c in f.arr)
                {
                    Console.WriteLine(c.number);
                }
                Console.Read();
            }
        }
    }
