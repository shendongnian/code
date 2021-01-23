    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var sessionModel = new SessionModel(3);
    
                // first case (see text down below):
                var catalog = new AssemblyCatalog
                  (System.Reflection.Assembly.GetExecutingAssembly());
    
                var compositionContainer = new CompositionContainer(catalog);
    
                // second case (see text down below):
                //var typeCatalog = new TypeCatalog(typeof (SessionModel));
                //var compositionContainer = new CompositionContainer(typeCatalog);
    
                //compositionContainer.ComposeExportedValue(sessionModel);
                var someService = compositionContainer.GetExportedValue<ISomeService>();
                someService.DoSomething();
            }
        }
    
        public class SessionModel
        {
            private int AValue { get; set; }
    
            [Export(typeof(ISomeService))]
            public ISomeService SomeService { get; private set; }
    
            public SessionModel()
            {
                SomeService = new SomeService();
            }
            public SessionModel(int aValue)
            {
                AValue = aValue;
                // of course, there is much more to do here in reality:
                SomeService = new SomeService();
            }
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
    }
