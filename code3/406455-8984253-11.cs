    public class BusinessLayerPackage : IPackage
    {
        public RegisterServices(Container container)
        {
            container.Register<IBar, Bar>(Lifestyle.Scoped);
            container.Register<IFoo, Foo>(Lifestyle.Singleton);            
        }
    }
    public static void Main(string[] args)
    {
        var container = new SimpleInjector.Container();
        
        container.RegisterPackages(AppDomain.CurrentDomain.GetAssemblies());
    }
