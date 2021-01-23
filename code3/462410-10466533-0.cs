    using System;
    using String = System.Func<System.String>;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                String myString = () => "Foo";
                // myString is now a function returning the string "Foo".  Yikes.
            }
        }
    }
