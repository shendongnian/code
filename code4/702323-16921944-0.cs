    class Program
    {
        static void Main(string[] args)
        {
            Cars car = Cars.Audi;
            Console.WriteLine("{0}.{1}", car.GetType().FullName, Enum.GetName(typeof(Cars), car));
        }
    }
    enum Cars { Audi, BMW, Ford }
