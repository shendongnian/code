    public class CoreDataPackage : IPackage {
        public void RegisterServices(Container container) {
            container.Register<ISomeService,SomeImplementation>();
            // etc...
        }
    }
