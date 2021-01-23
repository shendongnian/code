    public class AutoModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicle>().To<Car>().Named("Small");
            Bind<IVehicle>().To<Bus>().Named("Big");
            Bind<IVehicle>().To<Truck>().Named("Huge");
        }
    }
