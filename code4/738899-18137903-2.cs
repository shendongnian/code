    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.ReflectionModel;
    using System.Reflection;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        public static class MoreExtensions
        {
            public static T GetExport<T>(this object obj)
            {
                var pList = obj.GetType().GetProperties().Where(o => o.PropertyType == typeof(T)).ToList();
                if (pList.Count == 1)
                {
                    return (T)pList[0].GetValue(obj, null);
                }
                return default(T);
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
                ISomeService someService = sessionModel.GetExport<ISomeService>();
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
