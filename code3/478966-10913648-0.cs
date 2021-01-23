    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication4
    {
        class MyCustomAttribute : Attribute { }
        class FooClass
        {
            [MyCustom]
            public void DecoratedMethod() { Console.WriteLine("Decorated Method - executed."); }
            public void NotDecoratedMethod() { Console.WriteLine("Not Decoreated Method - executed."); }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                FooClass instanceOfFooClass = new FooClass();
                Foo(instanceOfFooClass.DecoratedMethod);
                Foo(instanceOfFooClass.NotDecoratedMethod);
                Console.ReadLine();
            }
    
            public static void Foo(Action action)
            {
                if (Attribute.GetCustomAttributes(action.Method, typeof(MyCustomAttribute)).Count() == 0)
                    Console.WriteLine(string.Format("Invalid method {0}", action.Method.Name));
                else
                {
                    Console.WriteLine(string.Format("Valid method {0}", action.Method.Name));
                    action.Invoke();
                }
            }
        }
    }
