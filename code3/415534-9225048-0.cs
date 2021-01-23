    RESULTS:
    00:00:00.2462702 : Resolve ContainerControlledLifetimeManager
    00:00:00.0014184 : Plain assignment
    00:00:00.3514334 : Resolve PerResolveLifetimeManager 
    00:00:00.0019258 : Direct instantiation
    class Program
    {
        static readonly IUnityContainer _container = new UnityContainer();
        static void Main(string[] args)
        {
            _container.RegisterType(typeof(IInterfaceOne), typeof (ClassOne), new ContainerControlledLifetimeManager());
            _container.RegisterType(typeof(IInterfaceTwo), typeof(ClassTwo), new PerResolveLifetimeManager());
            var classOne = new ClassOne();
            DoLots("Resolve ContainerControlledLifetimeManager", ()=>_container.Resolve<IInterfaceOne>());
            DoLots("Plain assignment", () =>classOne);
            DoLots("Resolve PerResolveLifetimeManager ", () => _container.Resolve<IInterfaceTwo>());
            DoLots("Direct instantiation", () => new ClassTwo());
            Console.ReadLine();
        }
        static void DoLots(string msg, Func<object> resolveFunc)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 100000; i++)
            {
                var instance = resolveFunc();
            }
            stopwatch.Stop();
            Console.WriteLine(string.Format("{0} : {1}",stopwatch.Elapsed , msg ));
        }
    }
    
    public interface IInterfaceOne{}
    public interface IInterfaceTwo{}
    public class ClassOne : IInterfaceOne{}
    public class ClassTwo : IInterfaceTwo{}
