    using System;
    using System.Reflection;
    
    namespace ConsoleApplication13
    {
        class Program
        {
            static void Main(string[] args)
            {
                AppDomain appDomain = AppDomain.CreateDomain("foo");
    
                IFoo foo = (IFoo)appDomain.CreateInstanceFromAndUnwrap(Assembly.GetEntryAssembly().Location, typeof(Foo).FullName);
    
                foo.SetSource("Foo Host");
    
                foo.DoSomething();
            }
        }
    
        public interface IFoo
        {
            void DoSomething();
            void SetSource(string source);
        }
    
        public class Foo : MarshalByRefObject, IFoo
        {
            public void DoSomething()
            {
                string source = Foo.Source;
    
                if (String.IsNullOrWhiteSpace(source))
                    source = "some default";
    
                Console.WriteLine(source);
            }
    
            public static string Source{get; private set;}
    
            public void SetSource(string source)
            {
                Foo.Source = source;
            }
        }
    }
