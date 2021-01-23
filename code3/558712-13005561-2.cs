    using System;
    using System.Runtime.CompilerServices;
    
    namespace ConsoleApplication6
    {
        public class Base<T>
            where T : Base<T>
        {
            static Base()
            {
                RuntimeHelpers.RunClassConstructor(typeof (T).TypeHandle);
            }
    
            public static void Foo()
            {
                Console.WriteLine("Bar");
            }
        }
    
        public class Base : Base<Base>
        {
        }
    
        public class A : Base<A>
        {
            static A()
            {
                Console.WriteLine("A cctor");
            }
        }
    
        public class B : Base<B>
        {
            static B()
            {
                Console.WriteLine("B cctor");
            }
    
            public new static void Foo()
            {
                Console.WriteLine("Bar!!");
                Base<B>.Foo();
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
