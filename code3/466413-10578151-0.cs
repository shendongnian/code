    class Program
    {
        static void Main()
        {
            var car = new Car();
            typeof (Car).GetMethod("Drive").Invoke(car, null);
        }
    }
    public class Car
    {
        public void Drive()
        {
            Console.WriteLine("Got here. Drive");
        }
    }
