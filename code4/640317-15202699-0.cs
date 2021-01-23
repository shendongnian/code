    public interface IFoo
    {
    }
    public interface IFooProvider
    {
    }
    public class Foo : IFoo
    {
       [Inject]
       public IFooProvider Provider { get; set; }
    }
    public class FooProvider : IFooProvider
    {
       private List<IFoo> _allFooServices;
       public FooProvider(IKernel kernel)
       {
          _allFooServices = kernel.GetAll<IFoo>().ToList();
       }
    }
    private static void Main(string[] args)
    {
       var IoC = new StandardKernel();
       IoC.Bind<IFoo>().To<Foo>().InSingletonScope();
       IoC.Bind<IFooProvider>().To<FooProvider>().InSingletonScope();
       var foo = IoC.Get<IFoo>();
     }
