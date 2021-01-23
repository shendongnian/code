    using System.Diagnostics;
    
    namespace ConsoleSandbox
    {
        interface IBar
        {
        }
    
        class Program
        {
            static void Foo<T>(T obj1) where T: IBar
            {
                Trace.WriteLine("Inside Foo<T>");
            }
    
    
            static void Foo(object obj)
            {
                Trace.WriteLine("Inside Foo Object");
            }
    
            static void Main(string[] args)
            {
    
                Foo("Hello");
            }
        }
    }
