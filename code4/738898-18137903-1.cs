    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.ReflectionModel;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
        public static class MoreExtensions
        {
            public static T GetExport<T>(this object obj,string propertyName,string contractName)
            {
                LazyMemberInfo info = new LazyMemberInfo(obj.GetType().GetProperty(propertyName));
                var ed = ReflectionModelServices.CreateExportDefinition(info, contractName, null, null);
                var ed1 = ReflectionModelServices.GetExportingMember(ed);
                T someService = (T)(ed1.GetAccessors().GetValue(0) as System.Reflection.MethodInfo).Invoke(obj, null);
                return (T)someService;
            }
        }
        internal class Program
        {
            private static void Main(string[] args)
            {
                var sessionModel = new SessionModel(3);
    // first case (see text down below):
                
                var compositionContainer = new CompositionContainer();
    
                // second case (see text down below):
                //var typeCatalog = new TypeCatalog(typeof (SessionModel));
                //var compositionContainer = new CompositionContainer(typeCatalog);
                //compositionContainer.ComposeExportedValue(sessionModel);
                ISomeService someService = sessionModel.GetExport<ISomeService>("SomeService",sessionModel.cname);
                someService.DoSomething();
            }
        }
    
        public class SessionModel
        {
            private int AValue { get; set; }
    
            [Export("One",typeof(ISomeService))]
            public ISomeService SomeService { get; private set; }
    
            
            public SessionModel(int aValue)
            {
                AValue = aValue;
                // of course, there is much more to do here in reality:
                SomeService = new SomeService();
            }
    
            public string cname { get { return "One"; } }
        }
    
        public class SessionModel1
        {
            private int AValue { get; set; }
    
            [Export("Two",typeof(ISomeService))]
            public ISomeService SomeService { get; private set; }
    
            public SessionModel1(int aValue)
            {
                AValue = aValue;
                // of course, there is much more to do here in reality:
                SomeService = new SomeService1();
            }
            public string cname { get { return "Two"; } }
    
        }
    
        public interface ISomeService
        {
            void DoSomething();
        }
    
        public class SomeService : ISomeService
        {
            public void DoSomething()
            {
                Console.WriteLine("DoSomething called");
                Console.ReadKey();
            }
        }
    
        public class SomeService1 : ISomeService
        {
            public void DoSomething()
            {
                Console.WriteLine("DoSomething called 1");
                Console.ReadKey();
            }
        }
    }
