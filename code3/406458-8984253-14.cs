    public class BusinessLayerPackage : IPackage
    {
        public void RegisterServices(Container container) //comment has been added because edit must be at least six char, please remove
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
