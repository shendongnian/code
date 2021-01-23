    interface IVehicleFactory<out T> where T : Vehicle
    {
        T Create();
    }
    class CarFactory : IVehicleFactory<Car>
    {
        public Car Create()
        {
            return new Car();
        }
    }
    class VehicleFactoryProvider
    {
        public IVehicleFactory<T> GetFactoryFor<T>() where T : Vehicle
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            VehicleFactoryProvider provider = new VehicleFactoryProvider();
            var factory = provider.GetFactoryFor<Car>();
            var car = factory.Create();
        }
    }
