    public class ServiceModule : NinjectModule
    {
        public override void Load() 
        {
            Bind<IService>().To<RealService>();
        }
    }
