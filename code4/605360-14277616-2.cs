    public class AutoModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicle>().To<Car>();
            Bind<IVehicle>().To<Bus>();
            Bind<IVehicle>().To<Truck>();
        }
    }
