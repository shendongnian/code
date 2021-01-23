    using Ninject.Factories; // can't quite remember namespace at the moment
    
    public class FactoryModule : NinjectModule {
        protected override void Load() {
            Bind<IMainFormFactory>().ToFactory();
        }
    }
