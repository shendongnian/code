    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAbstraction>().To<Implemtation>();
        }
    }
