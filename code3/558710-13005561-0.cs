    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    
    namespace ConsoleApplication6
    {
        public class Base
        {
            static Base()
            {
                Console.WriteLine("Base cctor");
    
                var thisType = typeof (Base);
                var loadedTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes());
                var derivations = loadedTypes.Where(thisType.IsAssignableFrom);
    
                foreach(var derivation in derivations)
                {
                    RuntimeHelpers.RunClassConstructor(derivation.TypeHandle);
                }
            }
    
            public static void Foo()
            {
                Console.WriteLine("Bar");
            }
        }
    
        public class A : Base
        {
            static A()
            {
                Console.WriteLine("A cctor");
            }
        }
    
        public class B : Base
        {
            static B()
            {
                Console.WriteLine("B cctor");
            }
    
            public new static void Foo()
            {
                Console.WriteLine("Bar!!");
                Base.Foo();
            }
        }
    
        class Program
        {
            static void Main()
            {
                Console.WriteLine("A:");
                A.Foo();
                Console.WriteLine();
                Console.WriteLine("B:");
                B.Foo();
                Console.WriteLine();
                Console.WriteLine("Base:");
                Base.Foo();
                Console.ReadLine();
            }
        }
    }
