    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SimpleInjector;
    public interface IMyManager { }
    public interface IMyFactory { }
    public interface IMyService { }
    public class MyManager : IMyManager
    {
        public MyManager(IMyFactory factory) { }
    }
    public class MyFactory : IMyFactory
    {
        public MyFactory(
            IEnumerable<IMyService> services)
        {
            Console.WriteLine("MyFactory(Count: {0})",
                services.Count());
        }
    }
    public class Service1 : IMyService { }
    public class Service2 : IMyService { }
    public class Service3 : IMyService { }
    public class Service4 : IMyService { }
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            container.Register<IMyFactory, MyFactory>(); 
            container.Register<IMyManager, MyManager>(); 
            container.RegisterAll<IMyService>(
	            from nd in AppDomain.CurrentDomain.GetAssemblies()
	            from type in nd.GetExportedTypes()
	            where !type.IsAbstract 
	            where typeof(IMyService).IsAssignableFrom(type) 
	            select type); 
	
            var myManager = container.GetInstance<IMyManager>();
            Console.WriteLine("IMyService count: " + 
                container.GetAllInstances<IMyService>().Count());
        }
    }
