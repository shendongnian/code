        public class CarFactoryKernel : StandardKernel, ICarFactoryKernel{
        public static readonly ICarFactoryKernel _instance = new CarFactoryKernel();
        public static ICarFactoryKernel Instance { get => _instance; }
        private CarFactoryKernel()
        {
            var carFactoryModeule = new List<INinjectModule> { new FactoryModule() };
            Load(carFactoryModeule);
        }
        public ICar GetCarFromFactory(string name)
        {
            var cars = this.GetAll<ICar>();
            foreach (var car in cars)
            {
                if (car.CarModel == name)
                {
                    return car;
                }
            }
            return null;
        }
    }
    public interface ICarFactoryKernel : IKernel
    {
        ICar GetCarFromFactory(string name);
    }
