    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.ReflectionModel;
    using System.Reflection;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
    
                var catalogs = new AggregateCatalog();
                var catalog = new System.ComponentModel.Composition.Hosting.AssemblyCatalog(Assembly.GetExecutingAssembly());
                catalogs.Catalogs.Add(catalog);
                var sessionModel = new SessionModel(3);
                var container = new CompositionContainer(catalog); 
                ISomeService someService = container.GetExportedValueOrDefault<ISomeService>(sessionModel.cname);
                if (someService != null)
                {
                    someService.DoSomething();
                }
            }
        }
    
        public class SessionModel
        {
            private int AValue { get; set; }
    
            //[Import("One",typeof(ISomeService))]
            //public ISomeService SomeService { get; private set; }
    
            public SessionModel(int aValue)
            {
                AValue = aValue;
                // of course, there is much more to do here in reality:
            }
    
            public string cname { get { return "One"; } }
        }
    
        public class SessionModel1
        {
            private int AValue { get; set; }
    
            //[Import("Two",typeof(ISomeService))]
            //public ISomeService SomeService { get; private set; }
    
            public SessionModel1(int aValue)
            {
                AValue = aValue;
            }
            public string cname { get { return "Two"; } }
    
        }
    
        public interface ISomeService
        {
            void DoSomething();
        }
    
        [Export("One",typeof(ISomeService))]
        public class SomeService : ISomeService
        {
            public SomeService()
            {
                Console.WriteLine("Some Service Called");
            }
            public void DoSomething()
            {
                Console.WriteLine("DoSomething called");
                Console.ReadKey();
            }
        }
    
        [Export("Two",typeof(ISomeService))]
        public class SomeService1 : ISomeService
        {
             public SomeService1()
            {
                Console.WriteLine("Some Service1 Called");
            }
            public void DoSomething()
            {
                Console.WriteLine("DoSomething called 1");
                Console.ReadKey();
            }
        }
    }
