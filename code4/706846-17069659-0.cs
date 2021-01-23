    using System;
    using System.Reflection;
    
    namespace ConsoleApplication13
    {
        class Program
        {
            static void Main(string[] args)
            {
                AppDomain appDomain = AppDomain.CreateDomain("foo");
    
                appDomain.SetData(FooUtility.SourceKey, FooUtility.SourceValue);
    
                IFoo foo = (IFoo)appDomain.CreateInstanceFromAndUnwrap(Assembly.GetEntryAssembly().Location, typeof(Foo).FullName);
    
                foo.DoSomething();
            }
        }
    
        public static class FooUtility
        {
            public const string SourceKey = "Source";
            public const string SourceValue = "Foo Host";
        }
    
        public interface IFoo
        {
            void DoSomething();
        }
    
        public class Foo : MarshalByRefObject, IFoo
        {
            public void DoSomething()
            {
                string source = AppDomain.CurrentDomain.GetData(FooUtility.SourceKey) as string;
    
                if (String.IsNullOrWhiteSpace(source))
                    source = "some default";
    
                Console.WriteLine(source);
            }
        }
    }
