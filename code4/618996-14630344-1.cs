    using System;
    using System.Linq;
    using System.Reflection;
    
    namespace ConsoleApplication9
    {
        class Program
        {
            static void Main(string[] args)
            {
                IHelloWorld x = GetImplementation<IHelloWorld>(Assembly.GetExecutingAssembly());
                
                x.SayHello();
                Console.ReadKey();
    
            }
            static TInterface GetImplementation<TInterface>( Assembly assembly)
            {
                var types = assembly.GetTypes();
                Type implementationType = types.SingleOrDefault(t => typeof (TInterface).IsAssignableFrom(t) && t.IsClass);
    
    
                if (implementationType != null)
                {
                    TInterface implementation = (TInterface)Activator.CreateInstance(implementationType);
                    return implementation;
                }
                
                throw new Exception("No Type implements interface.");
                
            }
        }
        interface IHelloWorld
        {
            void SayHello();
        }
        class MyImplementation : IHelloWorld
        {
            public void SayHello()
            {
                Console.WriteLine("Hello world from MyImplementation!");
            }
        }
    
    }
